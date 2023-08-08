using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Booster : ScriptableObject
{
    /*
     * Scriptible objeler daha çok veri tutmak için tasarlanýr
     * Monobehavour gibi update, start, vs metotlarý yok
     * bu sýnýftan türeyen sýnýflar özelinde iþlem yapacaðýmýz için abstract olarak tanýmladýk
     */

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private float _duration;
    
    public float Duration => _duration;

    public abstract void OnAdded(BoosterContainer boosterContainer);

    public abstract void OnRemoved(BoosterContainer boosterContainer);


}
