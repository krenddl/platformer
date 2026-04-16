using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPositin = new Vector3(player.position.x, player.position.y, transform.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPositin, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
