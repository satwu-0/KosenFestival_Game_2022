using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

///<summary>
///落下物のクラス
///</summary>
public class FallObject : MonoBehaviour
{
    public float creditValue;
    void OnTriggerEnter(Collider other)
    {
        //地面と衝突して消える処理
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        //プレイヤーと衝突して消える処理
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Retest"))
            {
                //GameObjectはシーン上のオブジェクトなのでSelializefieldは使えない
                GameObject gameManager = GameObject.FindWithTag("GameManager");
                gameManager.gameObject.GetComponent<GameManager>().IncreaseCredit();
            }
            Destroy(this.gameObject);
        }
    }
}