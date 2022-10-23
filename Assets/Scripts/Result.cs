using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///GameMannagerから成績を取得するクラス
///</summary>
public class Result : MonoBehaviour
{
    [SerializeField]
    private Text firstResultCreditText;
    [SerializeField]
    private Text secondResultCreditText;
    [SerializeField]
    private Text thirdResultCreditText;
    [SerializeField]
    private Text fourthResultCreditText;
    [SerializeField]
    private Text fifthResultCreditText;

    [SerializeField]
    private Text ResultMassageText;

    [SerializeField]
    private string graduationMassage;
    [SerializeField]
    private string heldBackMassage;
    
    private float[] resultCredit;
    private int year;
    private bool isGraduate;
 
    void Start()
    {
        Time.timeScale = 1;
        resultCredit = GameManager.GetCredit();
        isGraduate = GameManager.GetGraduation();
        year = GameManager.GetYear();
        InputResult();
    }

    //成績をテキストに入力するメソッド
    private void InputResult(){
        int i = 1;
        while(i <= year)
        {
            if(i==1)
            {
                firstResultCreditText.text = $"{i}年目…{resultCredit[i]}単位";
            }
            if(i==2)
            {
                secondResultCreditText.text = $"{i}年目…{resultCredit[i]}単位";
            }
            if(i==3)
            {
                thirdResultCreditText.text = $"{i}年目…{resultCredit[i]}単位";
            }
            if(i==4)
            {
                fourthResultCreditText.text = $"{i}年目…{resultCredit[i]}単位";
            }
            if(i==5)
            {
                fifthResultCreditText.text = $"{i}年目…{resultCredit[i]}単位";
            }
        }
        if(isGraduate)
        {
            ResultMassageText.text = graduationMassage;
        }else
        {
            ResultMassageText.text = heldBackMassage;
        }
    }
}
