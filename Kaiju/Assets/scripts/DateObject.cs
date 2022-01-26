using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DateObject : MonoBehaviour
{

    /*
    F�rsta utkast. Tanken �r att dejtobjectet har listor p� olika object den gillar och inte gillar
    N�r vi i spelet g�r saker med v�r dejt "skjuter" vi osynligt de objektet p� dejten.
    den j�mf�r med sina listor och anv�nder state machines f�r att �ndra "mood"
    */

    public string Name;
    public enum Mood { Devestated, Sad, Neutral, Glad, Overjoyed };
    public int Age;

    //Det h�r kommer vi nog f� bryta ut senare men vi kan b�rja s� h�r.
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

    //Olika beteende varje frame baserat p� mood. Kanske inte beh�vs.
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
    
    //F�r enkelhetens skull kan vi "skjuta" osynliga object som mat eller dansr�relser p� dejten f�r att leverera vad som h�nt till dejt-objectet.
    void OnCollisionEnter(Collision collision)
    {
        int unAlteredPoints = _moodPoints;
        
        GameObject otherObject = collision.gameObject;

        // om n�got den har i sin "gillar lista" har h�nt �ka mood points
        foreach(GameObject like in Likes)
        {
            if(otherObject == like)
                _moodPoints++;
        }
        
        //och tv�rtom med "ogillar-lista"
        foreach(GameObject dislike in Dislikes)
        {
            if(otherObject == dislike)
                _moodPoints--;
        }


        // om n�got som �ndrat po�ngen h�nt s� r�kna ut nytt mood och s�tt det.
        if(unAlteredPoints != _moodPoints)
        {
            Mood moodFromPoints = CalculateMood(_moodPoints);
            SwitchMood(moodFromPoints);
        }
       
    }

    Mood CalculateMood(int points)
    {
        //Kolla att vi inte g�tt utanf�r v�r ram av k�nslo spektrum
        if(points < _minMoodPoints)
            points = _minMoodPoints;

        if(points > _maxMoodPoints)
            points = _maxMoodPoints;

        //'casta' om siffran till v�r k�nslo enum
        Mood newMode = (Mood)points; 

        return newMode;
    }


    //Vi delar upp end och start mood till tv� olika metoder d� det kan skifta �t olika h�ll
    void SwitchMood(Mood mood)
    {
        EndMood();
        StartMood(mood);
    }




    //h�r kan vi f� saker att h�nda n�r dejten slutar vara p� ett visst hum�r
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

    //h�r kan vi f� saker att h�nda n�r dejten b�rjar vara p� ett nytt hum�r
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