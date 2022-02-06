using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public GameObject[] props;
    int nr = 0;
    public static GameObject CurrentProp;

    public Game_Manager game_manager;

    void Start()
    {
        foreach (GameObject obj in props)
        {
            obj.SetActive(false);
        }

        CurrentProp = props[0];
        CurrentProp.SetActive(true);
        game_manager.SetSlectedProp(CurrentProp);
    }


    public void SetLook()
    {

        CurrentProp.SetActive(false);

        nr++;
        if (nr >= props.Length)
        { nr = 0; }

        CurrentProp = props[nr];

        CurrentProp.SetActive(true);

        game_manager.SetSlectedProp(CurrentProp);

    }

}
