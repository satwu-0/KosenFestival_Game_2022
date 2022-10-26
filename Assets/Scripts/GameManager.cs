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
    private GameObject sceneLoader;

    [SerializeField]
    private  float limitSecondsLength;
    [SerializeField]
    private float stopAppearSeconds;
    [SerializeField]
    private float appearRetestSeconds;

    //何年生かを表すyear変数をそのまま添え字に使うために要素数が6になっている
    [SerializeField]
    private float[] maxCredit = new float[6];
    //何年生かを表すyear変数をそのまま添え字に使うために要素数が6になっている
    [SerializeField]
    private float[] requiredCredit = new float[6];

    [SerializeField]
    private GameObject appearCreditParent;
    [SerializeField]
    private GameObject appearRetest;

    private float limitSeconds;
    private float remainSeconds;
    private float haveCredit;

    private float[] resultCredit = new float[6];

    private bool isGraduate;
    private bool isRetest;

    private int year = 1;
    private float  delayResultSeconds = 0.5f;


    ///<summary>
    ///所持単位を減らすメソッド
    ///</summary>
    public void DecreaseCredit(float decreaseValue)
    {
        if(haveCredit - decreaseValue >= 0)
        {
            haveCredit -= decreaseValue;
        }else{
            haveCredit = 0;
        }
    }

    ///<summary>
    ///所持単位を増やすメソッド
    ///</summary>
    public void IncreaseCredit()
    {
        haveCredit = requiredCredit[year];
    }

    ///<summary>
    ///ResultSceneに移動し，変数を渡すメソッド
    ///</summary>
    public async void ChangeResult()
    {
        var nextScene = await SceneLoader.Load<Result>("Result"); 
        nextScene.InputResult(resultCredit,year,isGraduate);
    }

    void Start()
    {
        limitSeconds = limitSecondsLength;
        haveCredit = maxCredit[year];
        appearRetest.SetActive(false);
        isRetest = false;
    }

    void FixedUpdate()
    {
        limitSeconds -= Time.deltaTime;
        remainSeconds = limitSeconds;
        timerText.text = $"{remainSeconds:F0}"; 

        creditText.text = $"{haveCredit:F0}/{requiredCredit[year]:F0}";

        if(remainSeconds <= stopAppearSeconds){
            appearCreditParent.SetActive(false);
        }

        if(remainSeconds <= appearRetestSeconds && haveCredit < requiredCredit[year] && !isRetest){
            appearRetest.SetActive(true);
            appearRetest.SetActive(false);
            isRetest = true;
        }

        if(remainSeconds <= 0){
            resultCredit[year] = haveCredit;
            if(haveCredit < requiredCredit[year])
            {
                Time.timeScale = 0;
                isGraduate = false;
                Invoke("ChangeResult",delayResultSeconds);
            }else if(year < 5)
            {
                year++;
                limitSeconds = limitSecondsLength;
                haveCredit = maxCredit[year];
                appearCreditParent.SetActive(true);
                isRetest = false;
            }else
            {
                Time.timeScale = 0;
                isGraduate = true;
                Invoke("ChangeResult",delayResultSeconds);
            }
        }
    }
}
