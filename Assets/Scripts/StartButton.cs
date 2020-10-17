using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public bool Pressed { get; set; } = false;

    public void StartGame()
    {
        Pressed = true;
        Debug.Log("Let's go!");
    }
}
