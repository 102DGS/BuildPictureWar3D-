using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject Cubes;
    Transform target;
    void Start()
    {
        var elements = Cubes.GetComponentsInChildren<Transform>();
        target = elements[Random.Range(0, elements.Length)];
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
    void Shoot()
    {
        Debug.Log("Shoot");
        Vector3 vectorToTarget = transform.position - target.position;
        GetComponent<Rigidbody>().AddForce(vectorToTarget * Random.Range(10,100),ForceMode.Impulse);
    }
}
