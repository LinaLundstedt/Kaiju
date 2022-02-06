using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{

    public Choices choices;
    private static string _selectedPropName = "";
    public bool LogChoices = true;


    //hämta vald prop så länge den är satt till ett värde
    public string GetSelectedPropName()
    {
        return _selectedPropName;
    }

    //hämta vald dejt så länge den är satt till ett värde
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
        choices.selectedProp = prop;
        _selectedPropName = choices.selectedProp.name;
        Debug.Log(choices.selectedProp.name);
    }

    public void SetSlectedDejt(Kaiju dejt)
    {
        Debug.Log("Selected Dejt: " + dejt.kaijuName);



        choices.selectedDejt = new Kaiju();
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
        if (Input.GetKeyDown("space"))
        {
            NextScene();
        }
    }

}
