using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

/// <summary>
/// スタミナ制御のクラス
/// </summary>
public class StatusModel : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public float NowSpeed = 4f;

    public int staminaMax = 100;

    public IntReactiveProperty staminaRP = new IntReactiveProperty();
    
    public int Stamina
    {
        get {return staminaRP.Value;}
        set {staminaRP.Value = value;}
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0 && staminaRP.Value >= 2)
        {
            staminaRP.Value -= 2;
            NowSpeed = player.playerFastSpeed;
        }
        else if(staminaRP.Value < 200)
        {
            staminaRP.Value++;
            NowSpeed = player.playerSpeed;
        }
    }
    

}
