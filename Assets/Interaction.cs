using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    public GameObject head;
    Selectable selectable;
    LayerMask myLayerMask;
    public int maxDistance = 10;
    bool isGrabed = false;

    void Start()
    {
        myLayerMask = LayerMask.GetMask("Ground", "Selectable");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (!isGrabed) { Grab(); }
            else { Ungrab(); }
            
        }
           
    }

    private void Ungrab()
    {
        if (selectable)
        {
            selectable.Deselect();
        }
        isGrabed = false;
    }
    private void Grab()
    {
        ray = new Ray(head.transform.position, head.transform.forward);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask: myLayerMask))
        {
            selectable = hit.collider.gameObject?.GetComponent<Selectable>();
            if (selectable)
            {
                selectable.Select(Camera.main.transform);
                isGrabed = true;
            }
        }
       
    }

}
