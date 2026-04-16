using UnityEngine;
using System.Collections;

public class MovingSpike : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 4f;
    public float waitTime = 1f;

    private bool movingToB = true;

    void Start()
    {
        StartCoroutine(MoveSpike());
    }

    IEnumerator MoveSpike()
    {
        while (true)
        {
            Vector3 start = movingToB ? pointA.position : pointB.position;
            Vector3 end = movingToB ? pointB.position : pointA.position;

            while (Vector3.Distance(transform.position, end) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, end, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = end;
            movingToB = !movingToB;

            yield return new WaitForSeconds(waitTime);
        }
    }
}