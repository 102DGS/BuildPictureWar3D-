using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Selectable
{
    public float gravitationSpeed;
    public bool isGrabed = false;
    

  

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
        if (isGrabed) toPoint();

    }
    public override void Select(Transform transform)
    {
        this.transform.parent = transform;
        isGrabed = true;
        _rigidbody.useGravity = false;
        gameObject.layer = LayerMask.NameToLayer("Grabed");
        _rigidbody.constraints = RigidbodyConstraints.None;
    }
    public override void Deselect()
    {
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        this.transform.parent = null;
        isGrabed = false;
        gameObject.layer = LayerMask.NameToLayer("Cube");
        _rigidbody.constraints = RigidbodyConstraints.None;

    }
    private void toPoint()
    {
        var target = transform.parent.position - transform.position + transform.parent.forward * 3;

        _rigidbody.velocity = target * gravitationSpeed;

    }
}
