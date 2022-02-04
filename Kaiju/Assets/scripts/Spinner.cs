using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector2 turn;

    void Update()
    {

        // Check for mouse input
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Am I being clicked?
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {

                    turn.x += Input.GetAxis("Mouse X");
                    transform.localRotation = Quaternion.Euler(0, -turn.x * 5, 0);

                }

            }

        }

    }



}
