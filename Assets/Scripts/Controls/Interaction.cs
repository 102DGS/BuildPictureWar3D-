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
    private int maxDistance = 5;
    bool isGrabed = false;

    void Start()
    {
        myLayerMask = HelpTool.selectableLayerMask;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (!isGrabed) { Grab(); }
            else { Ungrab(); }
            
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Activate();
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

    private void Activate()
    {
        ray = new Ray(head.transform.position, head.transform.forward);

        Debug.DrawRay(head.transform.position, head.transform.forward * 5, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f)) // CompareTag - сравнивает тег объекта с тегом в параметре метода (в данном случае с "StartButton")
        {
            var button = hit.collider.gameObject?.GetComponent<Button>();

            button.OnPressed();
            
        }

        /*if (Physics.Raycast(ray, out hit, 5f))
        {
            Button restartButton = hit.collider.gameObject?.GetComponent<RestartButton>();

            restartButton.OnPressed();
        }*/
    }
}
