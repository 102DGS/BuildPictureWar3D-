using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane : MonoBehaviour
{
    private LayerMask layerMask;

    public Color Color;
    public Color cubeColor;
    Cube cube;
    bool withCube;

    private void Start()
    {
        layerMask = HelpTool.selectableLayerMask;
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 5, Color.yellow);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 5,layerMask))
        {
            cube = hit.collider.gameObject.GetComponent<Cube>();
            
            if (cube)
            {
                if (cube.isGrabed)
                {
                    return;
                }
                cubeColor = cube.GetComponent<Renderer>().material.color;
                Attract(cube);
            }
            
        }
        else
        {
            cubeColor = new Color(0.5f, 0.5f, 0.5f, 0f);
            withCube = false;
        }
    }

    public bool isRightCube()
    {
        return Color == cubeColor;
    }

    private void Attract(Cube cube)
    {
        if (withCube) return;
        cube.gameObject.transform.position = transform.position + transform.forward * 0.6f;
        cube.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        withCube = true;
        
    }
}
    