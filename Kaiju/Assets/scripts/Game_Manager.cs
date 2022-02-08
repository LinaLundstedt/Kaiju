using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{

    public Choices choices;
    private static string _selectedPropName = "";
    private static string _selectedDateName = "";
    public bool LogChoices = true;


    //hämta vald prop så länge den är satt till ett värde
    public string GetSelectedPropName()
    {
        return _selectedPropName;
    }

    //hämta vald dejt så länge den är satt till ett värde
    public string GetSelectedDateName()
    {

        return _selectedDateName;
    }

    public void SetSlectedProp(GameObject prop)
    {
        choices.selectedProp = prop;
        _selectedPropName = choices.selectedProp.name;
        Debug.Log(_selectedPropName);
    }

    public void SetSlectedDejt(Kaiju dejt)
    {
        choices.selectedDejt = dejt;
        _selectedDateName = choices.selectedDejt.kaijuName;
        Debug.Log(_selectedDateName);
    }


    public void NextScene()
    {
        try
        {
            int i = SceneManager.GetActiveScene().buildIndex;
            i++;
            SceneManager.LoadScene(i);
        }
        catch (System.Exception)
        {
  
        }
      
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Date")
        {
            Debug.Log("SELECTED DATE: " + _selectedDateName);
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Date");

            foreach (GameObject go in gameObjectArray)
            {
                Debug.Log(go.name);
                if (go.name == _selectedDateName)
                {
                    Debug.Log("MATCH ON: " + _selectedDateName + " : " + go.name);
                    go.SetActive(true);
                }
                else
                {
                    Debug.Log("NO MATCH ON: " + _selectedDateName + " : " + go.name);
                    go.SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown("space"))
        {
            NextScene();
        } */
    }

}
