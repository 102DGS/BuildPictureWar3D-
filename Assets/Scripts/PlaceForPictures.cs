using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private const int strings = 3;
    private const int columns = 4;

    private Plane plane;

    private string[,] tags = new string[strings, columns] { {"W", "W", "W", "W"}, { "B", "B", "B", "B" }, { "R", "R", "R", "R" } };   

    private void Awake()
    {
        plane = Resources.Load<Plane>("Plane");
        for (int i = 0; i < strings; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, -i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.tag = tags[i, j];
            }
        }
    }

    void Update()
    {
        
    }
}
