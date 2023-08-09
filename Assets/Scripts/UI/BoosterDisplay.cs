using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterDisplay : MonoBehaviour
{
    // bu sýnýfýn amacý ilgili booster ýn ne olduðunu ve progress bar ýný göstermek
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
        // progress bar ýn nasýl dolduðunu göstereceðiz
        _fillBar.fillAmount = BoosterInstance.RemainingDuration / BoosterInstance.Booster.Duration; 

    }

}
