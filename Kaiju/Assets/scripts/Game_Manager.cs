using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{

    public Choices choices;

    private static string _selectedPropName = "";
    private static string _selectedDejtName = "";

    public bool LogChoices = true;


    //h�mta vald prop s� l�nge den �r satt till ett v�rde
    public string GetSelectedPropName()
    {
        return _selectedPropName;
    }

    //h�mta vald dejt s� l�nge den �r satt till ett v�rde
    public string  GetSelectedDateName()
    {
        return _selectedDejtName;
    }

    public void SetSlectedProp(GameObject prop)
    {
        choices.selectedProp = prop;
        _selectedPropName = choices.selectedProp.name;
        Debug.Log(choices.selectedProp.name);
    }

    public void SetSlectedDejt(Kaiju dejt)
    {
        choices.selectedDejt = dejt;
        _selectedDejtName = choices.selectedDejt.kaijuName;
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
        
        if(SceneManager.GetActiveScene().name == "Date")
        {
            Debug.Log("Selected Date: " + _selectedDejtName);


            //H�mta alla dates
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Date");

            Debug.Log("DATE COUNT : " + gameObjectArray.Length);

            foreach (var go in gameObjectArray)
            {
                Debug.Log("FOUND DATE: " + go.name);
                if(go.name.ToLower() == _selectedDejtName.ToLower())
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }
            }
        }
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