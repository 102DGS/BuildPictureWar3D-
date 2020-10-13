using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ss : EventTrigger
{
    private int startFontSize;

    private void Awake()
    {
        startFontSize = GetComponentInChildren<Text>().fontSize;
    }



    public void MouseOn()
    {
        GetComponentInChildren<Text>().fontSize = startFontSize + 5;
    }


    public void MouseOut()
    {
        GetComponentInChildren<Text>().fontSize = startFontSize;
    }

    public void Click()
    {
        Debug.Log("Hello");
    }
}
