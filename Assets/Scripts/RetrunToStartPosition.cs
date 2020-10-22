using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrunToStartPosition : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    public Vector3 CurrentPosition
    {
        set { transform.position = value; }
    }

    public Quaternion CurrentRotation
    {
        set { transform.rotation = value; }
    }

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y <= -15f)
        {
            transform.position = startPosition + new Vector3(0f, 3f, 0f);
            transform.rotation = startRotation;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
