using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane : MonoBehaviour
{
    public LayerMask layerMack;

    public Color Color;
    public Color cubeColor;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 5, Color.yellow);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, layerMack))
        {
            Cube cube = hit.collider.gameObject.GetComponent<Cube>();
            if (cube)
            {
                cubeColor = cube.GetComponent<Renderer>().material.color;
                Attract(cube);
            }
        }
        else
        {
            cubeColor = new Color(0.5f, 0.5f, 0.5f, 0f);
        }
    }

    public bool isRightCube()
    {
        return Color == cubeColor;
    }

    private void Attract(Cube cube)
    {
        cube.gameObject.transform.position = transform.position + transform.forward * 2;
        cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
    