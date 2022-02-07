
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainFunctions : MonoBehaviour
{

    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
