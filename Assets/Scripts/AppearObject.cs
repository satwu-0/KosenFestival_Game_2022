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
    private float AppearInterval;

    private const float MinXPosition = -5.0f;
    private const float MaxXPosition = 5.0f;

    private const float AppearYPosition = 5f;
    private float appearXPosition;

    private Vector2 appearPosition;

        void Start ()
    {
        StartCoroutine (Appear());
    }

    private IEnumerator Appear() 
    {
        while(true)
        {
            yield return new WaitForSeconds (AppearInterval);
            RandomAppear();
        }
    }
    
    void RandomAppear()
    {
        appearXPosition = Random.Range(MinXPosition,MaxXPosition);
        appearPosition = new Vector2(appearXPosition,AppearYPosition);
        Instantiate(appearObject,appearPosition,Quaternion.identity);
    }
    
}
