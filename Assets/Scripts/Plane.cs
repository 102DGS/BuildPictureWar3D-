using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane : MonoBehaviour
{
    private SelectCube currentSelectable;
    public LayerMask layerMack;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 5, Color.yellow);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, layerMack))
        {
            Debug.Log("It is work!");

            SelectCube selectable = hit.collider.gameObject.GetComponent<SelectCube>();

            if (selectable)
            {
                if (currentSelectable && currentSelectable != selectable)
                {
                    currentSelectable.Deselect();
                }

                currentSelectable = selectable;
                currentSelectable.Select();
            }
            else
            {
                if (currentSelectable)
                {
                    currentSelectable.Deselect();
                    currentSelectable = null;
                }
            }
        }
        else
        {
            if (currentSelectable)
            {
                currentSelectable.Deselect();
                currentSelectable = null;
            }
        }
    }
}
    