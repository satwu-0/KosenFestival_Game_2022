using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

///<summary>
///落下物のクラス
///</summary>
public class FallObject : MonoBehaviour
{
    //public AudioClip sound1,sound2;
    //AudioSource audioSource;

    //void Start()
    //{
        //audioSource = GetComponent<AudioSource>();    
    //}

    void OnTriggerEnter(Collider other)
    {
        //地面と衝突して消える処理
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            //audioSource.PlayOneShot(sound1);
        }

        //プレイヤーと衝突して消える処理
        if(other.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject);
            //audioSource.PlayOneShot(sound2);
        }
    }

}
