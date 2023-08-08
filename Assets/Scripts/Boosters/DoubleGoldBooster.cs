using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/2x Gold")]
public class DoubleGoldBooster : Booster
{
    public override void OnAdded(BoosterContainer boosterContainer)
    {
        // booster topland���nda gold multiplier 2 olacak. b�ylece 2 kat alt�n toplanacak 

        GameInstance.Instance.GoldMultiplier = 2;
    }

    public override void OnRemoved(BoosterContainer boosterContainer)
    {
        GameInstance.Instance.GoldMultiplier = 1;
    }
}
