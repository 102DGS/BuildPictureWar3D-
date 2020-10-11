using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject Cubes;
    Transform target;
    public float minPower;
    public float maxPower;
    float curTime;
    void Start()
    {
        var elements = Cubes.GetComponentsInChildren<Transform>();
        target = elements[Random.Range(0, elements.Length)];
        transform.localScale = new Vector3(Random.Range(1f, 5f), Random.Range(1f, 5f), Random.Range(1f, 5f));
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        curTime = Time.time; 
    }

    private void Update()
    {
        if (Time.time > curTime+1 && Time.time < curTime+2) Shoot();
    }
    void Shoot()
    {
        Debug.Log("Shoot");
        Vector3 vectorToTarget = target.position - transform.position;
        GetComponent<Rigidbody>().velocity = (vectorToTarget * Random.Range(minPower,maxPower));
    }
}
