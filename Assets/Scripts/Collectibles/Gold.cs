using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectible
{
    protected override void OnCollected(GameObject collected)
    {
        // burada gold multiplier de�eri 2 ise 2 kat� kadar alt�n toplanacak

        GameInstance.Instance.Gold += Mathf.RoundToInt(1 * GameInstance.Instance.GoldMultiplier);

        Debug.Log(GameInstance.Instance.Gold);
    }
}

