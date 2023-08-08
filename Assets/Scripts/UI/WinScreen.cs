using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Button _nextLevelButton;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
    }



    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClicked);
    }

    private void OnNextLevelButtonClicked()
    {
        GameInstance.Instance.LoadCurrentLevel();
    }
}
