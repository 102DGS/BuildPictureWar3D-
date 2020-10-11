using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    Renderer[] cubes;
    void Start()
    {
        cubes = GetComponentsInChildren<Renderer>();
        foreach(var cube in cubes)
        {
            cube.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

   
}
