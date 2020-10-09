using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    RaycastHit[] allHits;
    Ray ray;
    public GameObject head;
    Selectable selectable = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ray = new Ray(head.transform.position,head.transform.forward);
        allHits = Physics.RaycastAll(ray,5f);
        foreach (var hit in allHits)
        {
            
            selectable = hit.collider.gameObject?.GetComponent<Selectable>();
            if (selectable)
            {
                selectable.Select();
            }
            }
        if (Input.GetMouseButton(0))
        {
            foreach (var hit in allHits)
            {

                selectable = hit.collider.gameObject?.GetComponent<Selectable>();
                if (selectable)
                {
                    selectable.Deselect();
                }
            }
        }
        allHits = null;
    }
   
}
