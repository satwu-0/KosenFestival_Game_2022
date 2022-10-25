using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///単位が地面に接触した時所持単位を減らすクラス
///</summary>
public class Ground : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    /*private GameObject credit;
    private CreditScript creditScript;*/

    private float decreaseValue;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Credit")){
            decreaseValue = other.gameObject.GetComponent<Credit>().creditValue;
        }   
        gameManager.gameObject.GetComponent<GameManager>().DecreaseCredit(decreaseValue);
    }
}
