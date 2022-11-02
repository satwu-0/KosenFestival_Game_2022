using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーの動作関係のクラス
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private StatusModel SM;

    public float playerSpeed = 4f;

    public float playerFastSpeed = 8f;

    float playerNowSpeed;

    [SerializeField]
    private float upForce = 350f;

    [SerializeField]
    private Rigidbody rb;
    
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private RectTransform pict;

    private bool isGround;



    public AudioClip sound1;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true; 
        }
    }

    void FixedUpdate()
    {
        playerNowSpeed = SM.NowSpeed;
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
            pict.transform.rotation = Quaternion.Euler(0,180,0);
        } 
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            playerPos.x -= playerNowSpeed * Time.deltaTime;
            pict.transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(isGround)
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            {
                isGround = false;
                audioSource.PlayOneShot(sound1);
                rb.AddForce(new Vector3(0, upForce, 0));
            }
        }

        transform.position = playerPos;
    }

}
