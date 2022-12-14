using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スタミナバーの表示関係のクラス
/// </summary>
public class ParameterBarView : MonoBehaviour
{
    [SerializeField]
    private RectTransform valueRect;

    public void SetRate(int max, int value)
    {
        valueRect.localScale = new Vector3((float)value / max, 1, 1);
    }
}
