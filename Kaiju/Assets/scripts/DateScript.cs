using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DateObject : MonoBehaviour
{

    /*
    Första utkast. Tanken är att dejtobjectet har listor på olika object den gillar och inte gillar
    När vi i spelet gör saker med vår dejt "skjuter" vi osynligt de objektet på dejten.
    den jämför med sina listor och använder state machines för att ändra "mood"
    */

    public string Name;
    public enum Mood { Devestated, Sad, Neutral, Glad, Overjoyed };
    public int Age;

    //Det här kommer vi nog få bryta ut senare men vi kan börja så här.
    public GameObject[] Likes;
    public GameObject[] Dislikes;

    Mood _mood;


    int _moodPoints = 0;
    int _minMoodPoints = 0;
    int _maxMoodPoints = 5;


    // Start is called before the first frame update
    void Start()
    {
        SwitchMood(Mood.Neutral);
    }

    //Olika beteende varje frame baserat på mood. Kanske inte behövs.
    void Update()
    {
        switch (_mood)
        {
            case Mood.Devestated:
                break;
            case Mood.Sad:
                break;
            case Mood.Neutral:
                break;
            case Mood.Glad:
                break;
            case Mood.Overjoyed:
                break;
            default:
                break;
        }
    }
    
    //För enkelhetens skull kan vi "skjuta" osynliga object som mat eller dansrörelser på dejten för att leverera vad som hänt till dejt-objectet.
    void OnCollisionEnter(Collision collision)
    {
        int unAlteredPoints = _moodPoints;
        
        GameObject otherObject = collision.gameObject;

        // om något den har i sin "gillar lista" har hänt öka mood points
        foreach(GameObject like in Likes)
        {
            if(otherObject == like)
                _moodPoints++;
        }
        
        //och tvärtom med "ogillar-lista"
        foreach(GameObject dislike in Dislikes)
        {
            if(otherObject == dislike)
                _moodPoints--;
        }


        // om något som ändrat poängen hänt så räkna ut nytt mood och sätt det.
        if(unAlteredPoints != _moodPoints)
        {
            Mood moodFromPoints = CalculateMood(_moodPoints);
            SwitchMood(moodFromPoints);
        }
       
    }

    Mood CalculateMood(int points)
    {
        //Kolla att vi inte gått utanför vår ram av känslo spektrum
        if(points < _minMoodPoints)
            points = _minMoodPoints;

        if(points > _maxMoodPoints)
            points = _maxMoodPoints;

        //'casta' om siffran till vår känslo enum
        Mood newMode = (Mood)points; 

        return newMode;
    }


    //Vi delar upp end och start mood till två olika metoder då det kan skifta åt olika håll
    void SwitchMood(Mood mood)
    {
        EndMood();
        StartMood(mood);
    }




    //här kan vi få saker att hända när dejten slutar vara på ett visst humör
    void EndMood()
    {
        switch (_mood)
        {
            case Mood.Devestated:
                break;
            case Mood.Sad:
                break;
            case Mood.Neutral:
                break;
            case Mood.Glad:
                break;
            case Mood.Overjoyed:
                break;
            default:
                break;
        }
    }

    //här kan vi få saker att hända när dejten börjar vara på ett nytt humör
    void StartMood(Mood mood)
    {
        switch (mood)
        {
            case Mood.Devestated:
                break;
            case Mood.Sad:
                break;
            case Mood.Neutral:
                break;
            case Mood.Glad:
                break;
            case Mood.Overjoyed:
                break;
            default:
                break;
        }
    }
}