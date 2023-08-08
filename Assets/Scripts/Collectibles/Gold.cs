using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Collectible
{
    protected override void OnCollected(GameObject collected)
    {
        // burada gold multiplier deðeri 2 ise 2 katý kadar altýn toplanacak

        GameInstance.Instance.Gold += Mathf.RoundToInt(1 * GameInstance.Instance.GoldMultiplier);

        Debug.Log(GameInstance.Instance.Gold);
    }
}

