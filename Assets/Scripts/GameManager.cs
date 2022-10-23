using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

///<summary>
///ゲームを管理するクラス
///</summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text creditText;

    [SerializeField]
    private  float limitSecondsLength;
    [SerializeField]
    private float stopAppearSeconds;
    [SerializeField]
    private float appearRetestSeconds;

    [SerializeField]
    private float[] maxCredit = new float[6];
    [SerializeField]
    private float[] requiredCredit = new float[6];

    [SerializeField]
    private GameObject appearCreditParent;
    [SerializeField]
    private GameObject appearRetest;

    private float limitSeconds;
    private float seconds;
    private float credit;

    public static float[] resultCredit = new float[6];

    public static bool isGraduate;
    private bool isRetest;

    public static int year = 1;
    private float  delayResultSeconds = 0.5f;


    ///<summary>
    ///所持単位を減らすメソッド
    ///</summary>
    public void DecreaseCredit(float decreaseValue)
    {
        if(credit - decreaseValue >= 0)
        {
            credit -= decreaseValue;
        }else{
            credit = 0;
        }
    }

    ///<summary>
    ///所持単位を増やすメソッド
    ///</summary>
    public void IncreaseCredit()
    {
        credit = requiredCredit[year];
    }

    ///<summary>
    ///最終的な成績をResultSceneに伝えるメソッド
    ///</summary>
    public static float[] GetCredit()
    {
        return resultCredit;
    }

    ///<summary>
    ///最終的な成績をResultSceneに伝えるメソッド
    ///</summary>
    public static bool GetGraduation()
    {
        return isGraduate;
    }

    ///<summary>
    ///何年生まで到達したかResultSceneに伝えるメソッド
    ///</summary>
    public static int GetYear()
    {
        return year;
    }

    ///<summary>
    ///ResultSceneに移動するまでに少し間をおくコルーチン
    ///</summary>
    private IEnumerator ChangeResult()
    {
        yield return new WaitForSecondsRealtime(delayResultSeconds);
        SceneManager.LoadScene("Result");
    }


    void Start()
    {
        limitSeconds = limitSecondsLength;
        credit = maxCredit[year];
        appearRetest.SetActive(false);
        isRetest = false;
    }

    void FixedUpdate()
    {
        limitSeconds -= Time.deltaTime;
        seconds = limitSeconds;
        timerText.text = $"{seconds:F0}"; 

        creditText.text = $"{credit:F0}/{requiredCredit[year]:F0}";

        if(seconds <= stopAppearSeconds){
            appearCreditParent.SetActive(false);
        }

        if(seconds <= appearRetestSeconds && credit < requiredCredit[year] && !isRetest){
            appearRetest.SetActive(true);
            appearRetest.SetActive(false);
            isRetest = true;
        }

        if(seconds <= 0){
            resultCredit[year] = credit;
            if(credit < requiredCredit[year])
            {
                Time.timeScale = 0;
                isGraduate = false;
                StartCoroutine(ChangeResult());
            }else if(year < 5)
            {
                year++;
                limitSeconds = limitSecondsLength;
                credit = maxCredit[year];
                appearCreditParent.SetActive(true);
                isRetest = false;
            }else
            {
                Time.timeScale = 0;
                isGraduate = true;
                StartCoroutine(ChangeResult());
            }
        }
    }
}
