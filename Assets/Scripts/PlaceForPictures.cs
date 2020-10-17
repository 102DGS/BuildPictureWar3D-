using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForPictures : MonoBehaviour
{
    private int rows;
    private int columns;
    private bool isVictory = false;


    public Color[] colors;
    public Color[] randomColors;
    private Plane plane;
    private GameObject cube;
    public GameObject picture;
    Picture _picture;

    private void Awake()
    {
        _picture = new Picture(1+Random.Range(0, Picture.currentPictures));
        colors = _picture.colors;
        rows = _picture.height;
        columns = _picture.width;
        randomColors = _picture.shufflingColors;
        SpawnPlates();
    }

    void Update()
    {
        if (CheckPicture() && !isVictory)
        {
            Victory();
            isVictory = true;
        }
            
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

    public void SpawnPlates()
    {
        
        
        
        
        
        plane = Resources.Load<Plane>("Plane");
        cube = Resources.Load<GameObject>("Cube");


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                newPlane.transform.parent = transform;
                newPlane.Color = colors[i * columns + j];
                cube.GetComponent<Renderer>().sharedMaterial.color = colors[i * columns + j];
                GameObject newCube = Instantiate(cube, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                
            }
        }
    }


}
