using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAround : MonoBehaviour
{
    Rigidbody rb;
    public float minSpeed;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0, Random.Range(minSpeed, maxSpeed), 0);
    }

    
}
