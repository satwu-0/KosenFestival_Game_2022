using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面におけるボタンの動きを管理するクラス
/// </summary>
public class Button : MonoBehaviour
{
    float ExpandingScale = 1.1f;
    float ShrinkScale = 1f;
    float ScaleChangeTime = 0.5f;
    [SerializeField] private SCENES scene;

    public enum SCENES
    {
        Main,
    }

    /// <summary>
    /// ボタンがクリックされたときボタンが一瞬拡大する
    /// </summary>
    public void OnClicked()
    {
        transform.DOScale(ExpandingScale,ScaleChangeTime)
        .SetEase(Ease.OutElastic)
        .OnComplete(() => transform.DOScale(ShrinkScale,ScaleChangeTime))
        .OnComplete(() => 
        SceneManager.LoadScene($"{scene}"));    
    }
    
}