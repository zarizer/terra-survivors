using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    public Transform Camera;
    public float smoothTime = 0.3f;
    private float z_pos = -100;

    void Start()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.z = z_pos;
        Camera.position = targetPosition;
    }

    void Update()
    {
        Vector3 targetPosition = Vector3.Lerp(Camera.position, transform.position, smoothTime);
        targetPosition.z = z_pos;
        Camera.position = targetPosition;
    }
}
