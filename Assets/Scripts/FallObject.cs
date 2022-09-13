using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

///<summary>
///落下物の動き
///</summary>
public class FallObject : MonoBehaviour
{

    private const float FallYPosition = 0f;
    private const float FallSeconds = 1.5f;

    void Start()
    {
        this.transform.DOMoveY(FallYPosition,FallSeconds).SetEase(Ease.InQuart);
    }

    void OnTriggerEnter(Collider other)
    {
        //地面と衝突して消える処理
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
            DOTween.Kill(this.transform);
        }
    }

}
