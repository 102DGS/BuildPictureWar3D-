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
        var ground = Resources.Load<GameObject>("Ground");
        cube = Resources.Load<GameObject>("Cube");
        var picturePattern = new GameObject("PicturePattern");
        var pictureFrame = new GameObject("PictureFrame");
        var picturePixels = new GameObject("PicturePixels");
        pictureFrame.transform.parent = picturePattern.transform;
        pictureFrame.AddComponent<MeshCombiner>();
        pictureFrame.AddComponent<MeshRenderer>();
        pictureFrame.AddComponent<MeshFilter>();
        picturePixels.transform.parent = picturePattern.transform;
        for (int i = -1; i < rows+1; i++)
        {
            for (int j = -1; j < columns+1; j++)
            {
                if (i == -1 || j == -1 || i == rows || j == columns)
                {
                    GameObject newCube1 = Instantiate(ground, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                    newCube1.transform.parent = transform;
                    GameObject newCube2 = Instantiate(ground, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                    newCube2.transform.parent = pictureFrame.transform;
                }
                else
                {
                    Plane newPlane = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                    newPlane.transform.parent = transform;
                    newPlane.Color = colors[i * columns + j];
                    GameObject newCube = Instantiate(cube, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                    newCube.transform.parent = picturePixels.transform;

                    newCube.GetComponent<Renderer>().material.color = colors[i * columns + j];
                }
                
            }
        }


    }


}
