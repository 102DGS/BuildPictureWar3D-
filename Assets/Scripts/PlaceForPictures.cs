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
    public Color[] setColors;
    private Plane plane;
    private GameObject cube;
    public GameObject picture;
    Picture _picture;

    private void Awake()
    {
        _picture = new Picture(1+Random.Range(0, Picture.currentPictures));
        //_picture = new Picture(15);
        colors = _picture.colors;
        rows = _picture.height;
        columns = _picture.width;
        randomColors = _picture.shufflingColors;
        setColors = _picture.setColors;
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
        var frame = Resources.Load<GameObject>("Ground");
        cube = Resources.Load<GameObject>("Cube");

        var picturePattern = new GameObject("PicturePattern");


        var pictureFrames = new GameObject("PictureFrame");
        pictureFrames.transform.parent = picturePattern.transform;
        pictureFrames.AddComponent<MeshRenderer>();

        var picturePixels = new GameObject("PicturePixels");
        pictureFrames.AddComponent<MeshFilter>();
        picturePixels.transform.parent = picturePattern.transform;

        for (int i = -1; i < rows+1; i++)
        {
            for (int j = -1; j < columns+1; j++)
            {
                if (i == -1 || j == -1 || i == rows || j == columns)
                {
                    GameObject groundFrame = Instantiate(frame, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                    groundFrame.transform.parent = transform;


                    GameObject pictureFrame = Instantiate(frame, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                    pictureFrame.transform.parent = pictureFrames.transform;

                    GameObject shootFrame = Instantiate(frame, picture.transform.position + new Vector3(j, i, -10f) - Vector3.up*(rows+10), Quaternion.Euler(0f, 0f, 0f));
                    shootFrame.transform.parent = transform;

                }
                else
                {
                    Plane groundCube = Instantiate(plane, transform.position + new Vector3(j, 0f, i), Quaternion.Euler(-90f, 0f, 0f));
                    groundCube.transform.parent = transform;
                    groundCube.Color = colors[i * columns + j];


                    GameObject pictureCube = Instantiate(cube, picture.transform.position + new Vector3(j, i, 0f), Quaternion.Euler(0f, 0f, 0f));
                    pictureCube.transform.parent = picturePixels.transform;
                    pictureCube.GetComponent<Rigidbody>().isKinematic = true;
                    pictureCube.GetComponent<Renderer>().material.color = colors[i * columns + j];

                    if (colors[i * columns + j] == Picture.neutralColor) continue;
                    GameObject shootCube = Instantiate(cube, picture.transform.position + new Vector3(j, i, -10f) - Vector3.up * (rows + 10), Quaternion.Euler(0f, 0f, 0f));
                    shootCube.transform.parent = transform;
                    shootCube.GetComponent<Rigidbody>().isKinematic = true;
                }
                
            }
        }


    }


}
