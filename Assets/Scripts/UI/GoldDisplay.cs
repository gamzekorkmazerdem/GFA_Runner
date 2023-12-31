using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    //private void Start()
    //{
    //    UpdateUI();
    //}
    private void OnEnable()
    {
        // burada GoldChaned event ine OnGoldChanged metodunu bağlıyoruz
        GameInstance.Instance.GoldChanged += OnGoldChanged;
        UpdateUI();
    }
    private void OnDisable()
    {
        GameInstance.Instance.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int gold)
    {
        UpdateUI(gold);
    }

    private void UpdateUI()
    {
        UpdateUI(GameInstance.Instance.Gold);
    }
    private void UpdateUI(int goldValue)
    {
        _text.text = goldValue.ToString();
    }

}
