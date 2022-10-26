using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///GameMannagerから成績を取得するクラス
///</summary>
public class Result : MonoBehaviour
{
    //何年生かを表すyear変数をそのまま添え字に使うために要素数が6になっている
    [SerializeField]
    private Text[] resultCreditTexts = new Text[6];

    [SerializeField]
    private Text resultMassageText;

    [SerializeField]
    private string graduationMassage;
    [SerializeField]
    private string heldBackMassage;
    
    public float[] resultCredits;
    public int year;
    public bool isGraduate;
 
    void Start()
    {
        Time.timeScale = 1;
    }

    //成績をテキストに入力するメソッド
    public void InputResult(float[] _resultCredits,int _year,bool _isGraduate){
        resultCredits = _resultCredits;
        year = _year;
        isGraduate = _isGraduate;
        for(int i = 1;i <= 5;i++)
        {
            if(i > year){
                break;
            }
            resultCreditTexts[i].text = $"{i}年目…{resultCredits[i]}単位";
        }
        if(isGraduate)
        {
            resultMassageText.text = graduationMassage;
        }else
        {
            resultMassageText.text = heldBackMassage;
        }
    }
}
