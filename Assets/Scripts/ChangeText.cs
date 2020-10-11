using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    int startFontSize;
    Vector3 startScale;

    private void Awake()
    {
        startScale = GetComponent<Button>().transform.localScale;
    }

    void OnMouseOver()
    {
        GetComponent<Button>().transform.localScale = startScale + new Vector3(0.5f, 0.5f, 0f);
    }

    void OnMouseExit()
    {
        GetComponent<Button>().transform.localScale = startScale;
    }
}
