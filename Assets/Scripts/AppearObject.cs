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

    private const float MinXPosition = -5.0f;
    private const float MaxXPosition = 5.0f;

    private const float AppearYPosition = 5f;
    private float appearXPosition;

    private Vector2 appearPosition;
    
    void Start ()
    {
        StartCoroutine ("TestAppear");
    }

    //動きの確認用の処理
    private IEnumerator TestAppear() 
    {
        var testCount = 0;
        var maxTestCount = 15;
        float intervalSeconds = 1f;
        while(testCount<maxTestCount)
        {
            RandomAppear();
            testCount++;
            yield return new WaitForSeconds (intervalSeconds);
        }
    }

    void RandomAppear()
    {
        appearXPosition = Random.Range(MinXPosition,MaxXPosition);
        appearPosition = new Vector2(appearXPosition,AppearYPosition);
        Instantiate(appearObject,appearPosition,Quaternion.identity);
    }
    
}
