using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartLevelButtonClicked);
    }



    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartLevelButtonClicked);
    }

    private void OnRestartLevelButtonClicked()
    {
        GameInstance.Instance.RestartLevel();
    }
}
