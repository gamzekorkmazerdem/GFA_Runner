using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectible : Collectible
{
    /*
     * bu sýnýfýn görevi toplanan booster ýn türünü belirtmek 
    */
    [SerializeField]
    private Booster _booster;

    protected override void OnCollected(GameObject collected)
    {
        /*
        var component = collected.GetComponent<BoosterContainer>();
        if(component != null)
        {
            container.AddBooster(_booster);
        }
        
        yukarýdaki kýsým aþaðýdaki ile ayný iþi yapar
        */
        if (collected.TryGetComponent<BoosterContainer>(out BoosterContainer container))
        {
            container.AddBooster(_booster);
        }
    }
}
