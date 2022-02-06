using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{

    public Choices choices;
    public bool LogChoices = true;


    //h�mta vald prop s� l�nge den �r satt till ett v�rde
    public GameObject GetSelectedProp()
    {
        if(choices.selectedProp != null)
        {
            return choices.selectedProp;
        }

        return null;
    }

    //h�mta vald dejt s� l�nge den �r satt till ett v�rde
    public Kaiju GetSelectedDate()
    {
        if (choices.selectedDejt != null)
        {
            return choices.selectedDejt;
        }

        return null;
    }

    public void SetSlectedProp(GameObject prop)
    {
        Debug.Log("Selected Prop: " + prop.name);
        choices.selectedProp = prop;
    }

    public void SetSlectedDejt(Kaiju dejt)
    {

        Debug.Log("Selected Dejt: " + dejt.kaijuName);
        choices.selectedDejt = dejt;
    }


    public void NextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        i++;
        SceneManager.LoadScene(i);
    }









    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
