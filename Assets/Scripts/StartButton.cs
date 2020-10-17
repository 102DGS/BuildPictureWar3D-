using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Canvas canvas;
    public bool Pressed { get; set; } = false;

    public void StartGame()
    {
        canvas.gameObject.SetActive(true);
        Pressed = true;
    }
}
