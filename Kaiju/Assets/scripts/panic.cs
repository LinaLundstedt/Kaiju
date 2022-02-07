using System.Collections;
using UnityEngine;

public class panic : MonoBehaviour
{
    public float movementDuration = 2.0f;
    public float pause = 2.0f;
    private bool hasArrived = false;
    Vector3 targetPos = Vector3.zero;

    private void Update()
    {
       
        if (!hasArrived)
        {
            hasArrived = true;
            pause = Random.Range(-pause, pause);
            float randX = Random.Range(-1.0f, 1.0f);
            float randZ = Random.Range(-1.0f, 1.0f);
            targetPos = new Vector3(randX, transform.position.y, randZ);
            StartCoroutine(MoveToPoint(targetPos));

        }
    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(pause);
        hasArrived = false;
    }
}