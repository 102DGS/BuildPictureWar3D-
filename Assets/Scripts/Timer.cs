using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float leftTime = 120;
    public Text timerText;

    private void Awake()
    {
        timerText.text = currentTime(leftTime);
    }

    void Update()
    {
        leftTime -= Time.deltaTime;
        if (leftTime > 0)
        {
            timerText.text = currentTime(leftTime);
        }
        else
        {
            timerText.text = "Time left";
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
