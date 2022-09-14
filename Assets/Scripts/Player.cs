using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 4f;

    [SerializeField]
    private float playerFastSpeed = 8f;

    [SerializeField]
    private float upForce = 350f;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        MovePlayer();
        MoveFastPlayer();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void MovePlayer()
    {
        Vector3 playerPos = transform.position;

        if(Input.GetKey(KeyCode.D))
        {
            playerPos.x += playerNowSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,0,270);
        } 
        if(Input.GetKey(KeyCode.A))
        {
            playerPos.x -= playerNowSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,0,90);
        }
        if (isGround == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                isGround = false;
                rb.AddForce(new Vector3(0, upForce, 0));
            }
        }

        transform.position = playerPos;
    }

    void MoveFastPlayer()
    {
        playerNowSpeed = (Input.GetKey(KeyCode.LeftShift)) ? playerFastSpeed : playerSpeed;
    }


}
