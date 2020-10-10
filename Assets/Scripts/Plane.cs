using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane : MonoBehaviour
{
    public LayerMask layerMack;

    private Color color;
    public Color Color { get; set; }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 5, Color.yellow);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, layerMack))
        {
            Cube cube = hit.collider.gameObject.GetComponent<Cube>();

            Debug.Log($"{cube.GetComponent<Renderer>().material.color} ---- {color}");
        }
    }
}
    