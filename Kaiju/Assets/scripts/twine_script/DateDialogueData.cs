using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class DateDialogueData : MonoBehaviour
{
    public string DateName;
    public TextAsset twineText;
    public Dejt dejt;
    public Sprite profilePicHappy;
    public Sprite profilePicSad;
    public AudioClip Voice;
    void ParseText(TextAsset txt)
    {

        //PARSE TO NODES

        //Has to do this because of the text format that's downloaded
        string text = Regex.Replace(txt.text, "{.*?}", string.Empty);
        string[] blocks = text.Split(':');

        string CurrentLine;

        for (int i = 0; i < blocks.Length; i++)
        {
            //If textblock is not empty
            if (blocks[i].Length > 0)
            {
                //create a new node for this textblock
                Nodes node = new Nodes();


                //GET CLIENT NAME
                if (blocks[i].Contains('-'))
                {
                    CurrentLine = blocks[i].Split('-')[1];

                }


                //GET QUESTION
                if (blocks[i].Contains('['))
                {
                    string[] Questions = blocks[i].Split('[', '\n');
                    string thisQuestion = string.Empty;
                    int thisLove = 0;
                    string thisDestination = string.Empty;
                    string theEnd = string.Empty;

                    for (int f = 4; f < Questions.Length; f++)
                    {

                        if (Questions[f].Contains("]]"))
                        {

                            string love;

                            //get question before the lovepoints and destionation
                            CurrentLine = Questions[f].Substring(0, Questions[f].LastIndexOf("%"));
                            thisQuestion = CurrentLine;

                            //split between | to get both question and destination
                            //Get the love points
                            love = Questions[f].Split('%', '|')[1];
                            Debug.Log(love);
                            thisLove = Int32.Parse(love);

                            CurrentLine = Questions[f].Remove(Questions[f].Length - 3);

                            //last one doesn't have a destination, ignore that one
                            if (CurrentLine.Contains("|"))
                                thisDestination = CurrentLine.Split('|', '\n')[1];

                                //get the end
                                else if (CurrentLine.Contains("END"))
                                {
                                    theEnd = CurrentLine;
                                    thisDestination = theEnd;
                                }


                                //No empty questions
                                if (thisQuestion != string.Empty)
                                {
                                    Question question = new Question();
                                    question.question = thisQuestion;
                                    question.lovePoints = thisLove;
                                    question.destination = thisDestination;


                                    node.questions.Add(question);

                                }
                            Debug.Log(thisQuestion + " " + thisLove + " " + thisDestination);
                        }
                    }

                }

                CurrentLine = blocks[i].Split('\n')[0];
                //make sure text has some text
                if (CurrentLine.Length > 1)
                {
                    node.pathTitle = blocks[i].Split('\n')[0];
                }


                    //client response comes after the titles, one line down
                    CurrentLine = blocks[i].Split('\n')[1];

                    //make sure client is saying something
                    if (CurrentLine.Length > 1)
                    {
                        node.feeling = blocks[i].Last().ToString();
                        string response = blocks[i].Split('\n')[1];
                        node.clientTxt = response.Remove(response.Length - 1);
                    }

                    dejt.nodes.Add(node);


            }

        }

    }

    void Awake()
    {
        ParseText(twineText);

    }

    private static int GetFirstIntFromString(string Str)
    {
        string strNr = string.Empty;
        int result = -1;

        for (int i = 0; i < Str.Length; i++)
        {
            if (Char.IsDigit(Str[i]))
            {
                strNr += Str[i];
                result = int.Parse(strNr);
                return result;
            }
        }
        return result;
    }
}


    [Serializable]

    public class Dejt
    {
    public string opener = string.Empty;
    public Nodes currentNode = null;
    public List<Nodes> nodes = new List<Nodes>();
    }

    public class Nodes
    {
        public string pathTitle;
        public string clientTxt;
        public string feeling;
        public List<Question> questions = new List<Question>();
    }

    public class Question
    {
        public string question;
        public string destination;
        public int lovePoints;
    }








