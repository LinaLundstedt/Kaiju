using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="new Kaiju", menuName ="Kaiju")]
public class Kaiju : ScriptableObject
{
    public int age;
    public string kaijuName;
    public Sprite tinderPic;
    public enum Mood { Devestated, Sad, Neutral, Glad, Overjoyed };


    private Mood _mood = Mood.Neutral;

    public string likedProp;

    public GameObject[] Likes;
    public GameObject[] Dislikes;


    int _moodPoints = 0;
    int _minMoodPoints = 0;
    int _maxMoodPoints = 5;

}
