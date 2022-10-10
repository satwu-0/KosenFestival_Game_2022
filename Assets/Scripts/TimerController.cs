using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///制限時間を表示するクラス
///</smmary>
public class TimerController : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private  float limitSeconds;

    private float seconds;

    void FixedUpdate()
    {
        limitSeconds -= Time.deltaTime;
        seconds = limitSeconds;
        timerText.text = $"{seconds:F0}"; 
        if(seconds <= 0){
            Time.timeScale = 0;
        }
    }
}
