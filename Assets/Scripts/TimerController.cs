using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    private  float LimitTime = 31;
    private int seconds;

    void FixedUpdate()
    {
        LimitTime -= Time.deltaTime;
        seconds = (int)LimitTime;
        timerText.text = seconds.ToString(); 
        if(seconds <= 0){
            Time.timeScale = 0;
        }
    }
}
