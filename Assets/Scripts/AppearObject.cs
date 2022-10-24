using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///落下物を生成するクラス
///</summary>
public class AppearObject : MonoBehaviour
{
    [SerializeField]
    private GameObject appearObject;
    [SerializeField]
    private float maxAppearIntervalSeconds;
    [SerializeField]
    private float minAppearIntervalSeconds;
    [SerializeField]
    private float minPositionX;
    [SerializeField]
    private float maxPositionX;

    private const float AppearPositionY = 5f;
    private float appearPositionX;

    private float appearIntervalSeconds;

    private Vector2 appearPosition;

    //アクティブになった時，生成物が単位ならコルーチンを開始，再試なら一度だけ生成を行う
    void OnEnable()
    {
        if(appearObject.CompareTag("Retest"))
        {
            RandomAppear();
        }else{
            StartCoroutine (Appear());
        } 
    }

    ///<summary>
    ///一定間隔で落下物の生成を行うコルーチン
    ///</summary>
    private IEnumerator Appear() 
    {
        while(true)
        {
            appearIntervalSeconds = Random.Range(minAppearIntervalSeconds,maxAppearIntervalSeconds);
            yield return new WaitForSeconds (appearIntervalSeconds);
            RandomAppear();
        }
    }
    
    ///<summary>
    ///ランダムに落下物を生成するメソッド
    ///</summary>
    void RandomAppear()
    {
        appearPositionX = Random.Range(minPositionX,maxPositionX);
        appearPosition = new Vector2(appearPositionX,AppearPositionY);
        Instantiate(appearObject,appearPosition,Quaternion.identity);
    }
    
}
