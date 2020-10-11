using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private int startFontSize;

    private void Awake()
    {
        startFontSize = GetComponentInChildren<Text>().fontSize;
    }

    void OnMouseOver()
    {
        GetComponentInChildren<Text>().fontSize = startFontSize + 5;
    }

    void OnMouseExit()
    {
        GetComponentInChildren<Text>().fontSize = startFontSize;
    }
}
