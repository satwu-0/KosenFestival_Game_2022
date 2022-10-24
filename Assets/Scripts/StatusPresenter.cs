using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// StatusModelとStatusPresenterを繋ぐクラス
/// </summary>
public class StatusPresenter : MonoBehaviour
{
    public StatusModel model;
    
    public ParameterBarView staminaView;

    void Awake()
    {
        model.staminaRP.Subscribe(value => {staminaView.SetRate(model.staminaMax,value);});
    }
    
}
