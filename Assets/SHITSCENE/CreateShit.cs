using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShit : MonoBehaviour
{
    public GameObject item;
    float currentTime = 5;

    private void Start()
    {
        GenerateShit();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Time.time > currentTime)
        {
            GenerateShit();
            currentTime = Time.time + 5;
        }
    }
    void GenerateShit()
    {
        Destroy(Instantiate(item), 5);
    }
}
