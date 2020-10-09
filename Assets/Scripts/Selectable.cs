using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    Color defaultColor;
    private void Awake()
    {
        defaultColor = GetComponent<Renderer>().material.color;
    }
    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void Deselect()
    {
        GetComponent<Renderer>().material.color = defaultColor;
    }
}
