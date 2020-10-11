using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private int rows;
    private int columns;

    private Plane plane;


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
        int numperOfPictures = HelpTool.numberOfPngInDirectory(Application.dataPath + "/Pictures"); // количество картинок в папке
        Color[] colors = HelpTool.imageToByteArray(picturesPath + $"/{Random.Range(1,numperOfPictures+1)}.png", out rows, out columns); // случайный выбор картинки и запись ее цветов в массив
        
        
        
        plane = Resources.Load<Plane>("Plane");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.Color = colors[i * columns + j];
            }
        }
    }


}
