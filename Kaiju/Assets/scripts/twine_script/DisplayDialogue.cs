using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogue : MonoBehaviour
{

    GameObject Date;
    Text displayTxt;
    public Image playerimg;
    public Image DateImg;
    public GameObject AnswerPrefab;
    public GameObject questionsPanel;
    public RectTransform displaySquare;

    DateDialogueData dejtData;

    AudioSource Audio;
    public AudioClip DateVoice;
    public AudioClip PlayerVoice;

    bool txtDone = true;
    bool dateAnswer = false;
    bool playerTalking = false;
    string nextSentence = string.Empty;
    int currentSenNr = 0;
    int fullSentanceNr = -1;



    Nodes currentNode;
    Nodes nextNode = null;
    string FullTalk;

    bool canClick = true;


    private void Awake()
    {
        Audio = gameObject.GetComponent<AudioSource>();
        Date = GameObject.FindGameObjectWithTag("Date");
        dejtData = Date.GetComponent<DateDialogueData>();

    }

    void Start()
    {
        displayTxt = displaySquare.GetComponentInChildren<Text>();

        Date = GameObject.FindGameObjectWithTag("Date");

        StartTalk(dejtData.dejt);
    }

    private void Update()
    {

        if (!txtDone)
        {

            if (Input.GetMouseButtonDown(0) && canClick)
            {

                if(playerTalking)
                {
                    playerTalking = false;
                    SetPath(nextNode);
                }


                if (currentSenNr >= fullSentanceNr)
                {
                    Debug.Log("end of date talking");
                    txtDone = true;
                    Question(nextNode);
                    dateAnswer = false;
                    currentSenNr = 0;
                }

                if (dateAnswer && !playerTalking)
                {
                    nextSentence = SentenceCut(currentSenNr, currentNode.clientTxt);
                    StartCoroutine(TypeText(nextSentence, displayTxt, DateVoice));
                    //currentSenNr = 0;
                }


               
            }

        }
    }

    public void StartTalk(Dejt dejten )
    {

        FullTalk = dejten.opener;
        Debug.Log(dejten.opener);
        playerTalk(FullTalk);

        currentNode = dejten.currentNode;
        nextNode = dejten.nodes[0];
        displayTxt.text = string.Empty;
    }

    public void AskQuestion(string question, string path)
    {
        GameObject q = createQuestion(question);
        q.GetComponent<Button>().onClick.AddListener(() => { SetNode(q, path, question); });

    }

    public void SetNode(GameObject question, string path, string fullTalk)
    {
       
        if (question != null)
        {
            for (int i = 0; i < dejtData.dejt.nodes.Count; i++)
            {
                if (dejtData.dejt.nodes[i].pathTitle.Contains(path))
                {
                    nextNode = dejtData.dejt.nodes[i];
                }
            }
            //Make the button go to next path

            question.GetComponent<Button>().onClick.AddListener(() => { playerTalk(fullTalk); });
        }
    }

    void playerTalk(string SpeeachString)
    {
        playerTalking = true;
        foreach (Transform child in questionsPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        StartCoroutine(TypeText(SpeeachString, displayTxt, null));

    }

    public void SetPath(Nodes node)
    {

        dejtData.dejt.currentNode = node;
        currentNode = node;

        currentSenNr = 0;
        nextSentence = SentenceCut(currentSenNr, currentNode.clientTxt);
        dateAnswer = true;
        txtDone = false;

    }


    string SentenceCut (int nextnr, string Wholetxt)
    {
        string chop = Wholetxt;
        string[] sentances = chop.Split('*');

        fullSentanceNr = sentances.Length;

        return sentances[nextnr];
    }


  
    void Question(Nodes node)
    {
        for (int i = 0; i <dejtData.dejt.currentNode.questions.Count; i++)
        {
            if(dejtData.dejt.currentNode.pathTitle.Contains("E"))
            {
                //DEJT SLUT
                return;
            }

                AskQuestion(node.questions[i].question, node.questions[i].destination);
        }
    }


    GameObject createQuestion(string Questiontxt)
    {
        GameObject q = Instantiate(AnswerPrefab, questionsPanel.transform.position, Quaternion.identity) as GameObject;
        q.transform.SetParent(questionsPanel.transform);
        q.GetComponentInChildren<Text>().text = Questiontxt;
        return q;
    }


    IEnumerator TypeText(string message, Text txtObj, AudioClip voice)
    {
        canClick = false;
        txtDone = false;
        int index = 0;
        string colorTag = "<color=#00000000>";
        float pause = 0.03f;
        txtObj.text = "";


        if (voice != null)
        {
            Audio.clip = voice;
            Audio.Play();
        }

        while (index <= message.Length)
        {
            string txt = message.Substring(0, index) + colorTag + message.Substring(index) + "</color>";
            txtObj.text = txt;
            index++;

            if(txt.EndsWith(".") || txt.EndsWith("."))
            {
              pause = 0.5f;

            }
             else
              pause = 0.03f;

            yield return new WaitForSeconds(pause);
        }

        canClick = true;
        currentSenNr += 1;
        yield return 0;
    }




}
