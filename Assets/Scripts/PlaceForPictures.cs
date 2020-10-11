using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private int rows;
    private int columns;

    private Plane plane;

    private Color[] colors;

    private void Awake()
    {


        Color[] colors = HelpTool.imageToByteArray(Application.dataPath + $"/{1}.png",out rows,out columns);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Debug.Log(i +" " + j + " is " + colors[i * columns + j]);
            }
        }
                plane = Resources.Load<Plane>("Plane");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.Color = colors[i*columns + j];
                //Debug.Log("Loaded pixel : " + colors[i * columns + j]);
            }
        }
    }

    void Update()
    {
        try
        {
            if (CheckPicture())
            {
                Debug.Log("Happy!!!");
            }
        }
        catch
        {
            Debug.Log("Error");
        }
    }

    private bool CheckPicture()
    {
        Plane[] planes = GetComponentsInChildren<Plane>();

        foreach (var plane in planes)
        {
            if (plane.Color != plane.cubeColor)
            {
                return false;
            }
        }
        return true;
    }
}
