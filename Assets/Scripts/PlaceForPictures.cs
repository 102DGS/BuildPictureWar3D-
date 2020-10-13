﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private int rows;
    private int columns;

    private Plane plane;
    private GameObject cube;
    public GameObject picture;

    private void Awake()
    {
        SpawnPlates();
    }

    void Update()
    {
        if (CheckPicture()) Victory();  
    }

    private bool CheckPicture()
    {
        Plane[] planes = GetComponentsInChildren<Plane>();

        foreach (var plane in planes)
        {
            if (!plane.isRightCube())
            {
                return false;
            }
        }
        return true;
    }

    private void Victory()
    {
        Debug.Log("Victory");
    }

    private void SpawnPlates()
    {
        string picturesPath = Application.dataPath + "/Pictures";  //Путь к папке с картинками
        int numberOfPictures = HelpTool.numberOfPngInDirectory(Application.dataPath + "/Pictures"); // количество картинок в папке
        Color[] colors = HelpTool.imageToByteArray(picturesPath + $"/{Random.Range(1,numberOfPictures+1)}.png", out rows, out columns); // случайный выбор картинки и запись ее цветов в массив
        
        
        
        plane = Resources.Load<Plane>("Plane");
        cube = Resources.Load<GameObject>("RedCube");


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.Color = colors[i * columns + j];

                GameObject newCube = Instantiate(cube, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                newCube.GetComponent<Renderer>().material.color = colors[i * columns + j];
            }
        }
    }


}
