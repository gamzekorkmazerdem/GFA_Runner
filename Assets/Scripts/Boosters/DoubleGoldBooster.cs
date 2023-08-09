using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boosters/2x Gold")]
public class DoubleGoldBooster : Booster
{
    public override void OnAdded(BoosterContainer boosterContainer)
    {
        // booster toplandýðýnda gold multiplier 2 olacak. böylece 2 kat altýn toplanacak 

        GameInstance.Instance.GoldMultiplier = 2;
    }

    public override void OnRemoved(BoosterContainer boosterContainer)
    {
        GameInstance.Instance.GoldMultiplier = 1;
    }
}
