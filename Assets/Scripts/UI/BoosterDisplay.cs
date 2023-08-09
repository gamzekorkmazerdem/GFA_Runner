using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterDisplay : MonoBehaviour
{
    // bu s�n�f�n amac� ilgili booster �n ne oldu�unu ve progress bar �n� g�stermek
    public BoosterContainer.BoosterInstance BoosterInstance { get; set; }

    [SerializeField]
    private Image _boosterIcon;

    [SerializeField]
    private Image _fillBar;

    private void Start()
    {
        _boosterIcon.sprite = BoosterInstance.Booster.Icon;
    }

    private void Update()
    {
        // progress bar �n nas�l doldu�unu g�sterece�iz
        _fillBar.fillAmount = BoosterInstance.RemainingDuration / BoosterInstance.Booster.Duration; 

    }

}
