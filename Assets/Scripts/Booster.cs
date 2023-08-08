using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Booster : ScriptableObject
{
    /*
     * Scriptible objeler daha �ok veri tutmak i�in tasarlan�r
     * Monobehavour gibi update, start, vs metotlar� yok
     * bu s�n�ftan t�reyen s�n�flar �zelinde i�lem yapaca��m�z i�in abstract olarak tan�mlad�k
     */

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private float _duration;
    
    public float Duration => _duration;

    public abstract void OnAdded(BoosterContainer boosterContainer);

    public abstract void OnRemoved(BoosterContainer boosterContainer);


}
