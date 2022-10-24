using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーの動作関係のクラス
/// </summary>
public class Player : MonoBehaviour
{
    public static float playerSpeed = 4f;

    public static float playerFastSpeed = 8f;

    float playerNowSpeed;

    [SerializeField]
    private float upForce = 350f;

    [SerializeField]
    private Rigidbody rb;
    
    private bool isGround;



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true; 
        }
    }

    void FixedUpdate()
    {
        playerNowSpeed = StatusModel.NowSpeed;
        MovePlayer();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void MovePlayer()
    {
        Vector3 playerPos = transform.position;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            playerPos.x += playerNowSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0,0,270);
        } 
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            playerPos.x -= playerNowSpeed * Time.deltaTime;
            //transform.rotation = Quaternion.Euler(0,0,90);
        }
        if(isGround == true)
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                isGround = false;
                rb.AddForce(new Vector3(0, upForce, 0));
            }
        }

        transform.position = playerPos;
    }

}
