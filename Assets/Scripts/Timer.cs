﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float leftTime = 60f;
    public Text timerText;
    public GameObject gameController;

    private void Awake()
    {
        timerText.text = currentTime(leftTime);
    }

    void Update()
    {
        if (!gameController.GetComponent<PlaceForPictures>().isVictory)
        {
            leftTime -= Time.deltaTime;

            if (leftTime > 0)
            {
                timerText.text = currentTime(leftTime);
            }
            else if (leftTime > -2)
            {
                timerText.text = "Time left";
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            timerText.text = "Good work!";
        }
        
    }

    private string currentTime(float leftTime)
    {
        if ((int)Mathf.Round(leftTime) % 60 < 10)
        {
            return ($"Timer: {(int)Mathf.Round(leftTime) / 60}:0{(int)Mathf.Round(leftTime) % 60}");
        }
        else
        {
            return ($"Timer: {(int)Mathf.Round(leftTime) / 60}:{(int)Mathf.Round(leftTime) % 60}");
        }
    }
}
