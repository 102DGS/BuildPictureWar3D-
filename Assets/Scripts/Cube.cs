using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (transform.position.y <= -15f)
        {
            transform.position = startPosition + new Vector3(0f, 3f, 0f);
            transform.rotation = startRotation;
        }
    }
}
