using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///単位が地面に接触した時所持単位を減らすクラス
///</summary>
public class Ground : MonoBehaviour
{
    private float decreaseValue1 = 1;
    private float decreaseValue2 = 2;
    private float decreaseValue3 = 3;
    private float decreaseValue4 = 4;
    private float decreaseValue5 = 5;
    private float decreaseValue6 = 6;
    private float decreaseValue7 = 7;
    private float decreaseValue8 = 8;

    private GameObject gameManager;

    void Start(){
        gameManager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Credit1(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue1);
        }
        if(other.gameObject.name == "Credit2(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue2);
        }
        if(other.gameObject.name == "Credit3(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue3);
        }
        if(other.gameObject.name == "Credit4(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue4);
        }
        if(other.gameObject.name == "Credit5(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue5);
        }
        if(other.gameObject.name == "Credit6(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue6);
        }
        if(other.gameObject.name == "Credit7(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue7);
        }
        if(other.gameObject.name == "Credit8(Clone)")
        {
            gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue8);
        }
    }
}
