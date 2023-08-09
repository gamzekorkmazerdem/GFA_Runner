using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCollectible : Collectible
{
    /*
     * bu s�n�f�n g�revi toplanan booster �n t�r�n� belirtmek 
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
        
        yukar�daki k�s�m a�a��daki ile ayn� i�i yapar
        */
        if (collected.TryGetComponent<BoosterContainer>(out BoosterContainer container))
        {
            container.AddBooster(_booster);
        }
    }
}
