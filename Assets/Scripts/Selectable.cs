using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    Color defaultColor;
    Rigidbody rb;
    public float gravitationSpeed;
    Renderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        defaultColor = _renderer.material.color;
        rb = GetComponent<Rigidbody>();
    }
   


    public void Select(Transform transform)
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        this.transform.parent = transform;
        GetComponent<Cube>().isGrabed = true;
        rb.useGravity = false;
        gameObject.layer = LayerMask.NameToLayer("Grabed");
    }
    public void Deselect()
    {
        rb.useGravity = true;
        GetComponent<Renderer>().material.color = defaultColor;
        rb.velocity = Vector3.zero;
        this.transform.parent = null;
        GetComponent<Cube>().isGrabed = false;
        gameObject.layer = LayerMask.NameToLayer("Cube");
        rb.constraints = RigidbodyConstraints.None;

    }
    private void Update()
    {
        if (GetComponent<Cube>().isGrabed) toPoint();
    }
    private void toPoint()
    {
        var target = transform.parent.position - transform.position + transform.parent.forward*3;
        rb.velocity = target * gravitationSpeed;
;
    }
}

