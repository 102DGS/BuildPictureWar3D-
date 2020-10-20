using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    public GameObject head;
    Selectable selectable;
    LayerMask myLayerMask;
    private int maxDistance = 5;
    bool isGrabed = false;

    private Vector3 onNotUseableAimPointScale;
    private Vector3 onUseableAimPointScale;

    public Canvas aimCanvas;
    public RawImage img;

    void Start()
    {
        myLayerMask = HelpTool.selectableLayerMask;
        onNotUseableAimPointScale = img.GetComponent<RectTransform>().localScale;
        onUseableAimPointScale = onNotUseableAimPointScale + new Vector3(0.5f, 0.5f, 0f);
    }

    private void Update()
    {
        ray = new Ray(head.transform.position, head.transform.forward);
        Debug.DrawRay(head.transform.position, head.transform.forward * 5, Color.yellow);


        if (Input.GetMouseButtonDown(0))
        {
            if (!isGrabed) { Grab(); }
            else { Ungrab(); }

        }

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hit, maxDistance))
        {
            Activate();
        }

        if (Physics.Raycast(ray, out hit, maxDistance) && hit.collider.gameObject?.GetComponent<UseableObjects>())
        {
            img.GetComponent<RectTransform>().localScale = onUseableAimPointScale;
        }
        else
        {
            img.GetComponent<RectTransform>().localScale = onNotUseableAimPointScale;
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
        var button = hit.collider.gameObject?.GetComponent<Button>();

        if (button)
        {
            button.OnPressed();
        }
    }
}