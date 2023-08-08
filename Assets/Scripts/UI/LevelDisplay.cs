using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    //private void Start()
    //{
    //    UpdateUI();
    //}
    private void OnEnable()
    {
        // burada GoldChaned event ine OnGoldChanged metodunu baðlýyoruz
        GameInstance.Instance.LevelChanged += OnLevelChanged;
        UpdateUI();
    }
    private void OnDisable()
    {
        GameInstance.Instance.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        UpdateUI(level);
    }

    private void UpdateUI()
    {
        UpdateUI(GameInstance.Instance.Level);
    }
    private void UpdateUI(int levelValue)
    {
        _text.text = "Level: " + (levelValue + 1).ToString();
    }
}
