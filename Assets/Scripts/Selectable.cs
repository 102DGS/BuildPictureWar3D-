﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    Color defaultColor;
    private void Awake()
    {
        defaultColor = GetComponent<Renderer>().material.color;
    }
   


    public void Select(Transform transform)
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        this.transform.parent = transform;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Deselect()
    {
        GetComponent<Renderer>().material.color = defaultColor;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;

    }
    
}
