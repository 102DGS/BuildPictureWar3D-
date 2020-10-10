using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private const int rows = 3;
    private const int columns = 4;

    private Plane plane;

    private Color[] colors;

    private void Awake()
    {
        Color[] colors = StaticClass.imageByteArray(Application.dataPath + "/1.png");
        plane = Resources.Load<Plane>("Plane");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, -i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.Color = colors[i*rows + j];
            }
        }
    }

    void Update()
    {
        
    }
}
