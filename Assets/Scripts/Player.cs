using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動作関係のクラス
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 4f;

    [SerializeField]
    private float playerFastSpeed = 8f;

    [SerializeField]
    private float upForce = 350f;

    [SerializeField]
    private Rigidbody rb;
    
    private bool isGround;

    float playerNowSpeed;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true; 
        }
    }

    void FixedUpdate()
    {
        playerNowSpeed = (Input.GetKey(KeyCode.LeftShift)) ? playerFastSpeed : playerSpeed;
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
        if (isGround == true)
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
