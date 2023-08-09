using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterContainer : MonoBehaviour
{
    /*
     * Bu sýnýfýn görevi eklenen booster larýn yaþam döngüsünü kontrol etmek 
     * booster lar buraya eklenecek ve iþi bittiðinde kaldýrýlacak
     * 
     */
    public List<BoosterInstance> _activeBoosters = new List<BoosterInstance>();

    public event Action<BoosterInstance> BoosterAdded;
    public event Action<Booster> BoosterRemoved;

    public void AddBooster(Booster booster)
    {
        // bütün aktif booster lar kontrol edilir.
        // eðer daha önce eklenmiþ bir boostersa duration time ý resetlenir
        // yani 10 sn ise tekrar 10 sn atanýr
        // tekrar booster eklenmez
        foreach (var instance in _activeBoosters)
        {
            if(instance.Booster == booster)
            {
                instance.ResetDuration();
                return;
            }
        }
        var boosterInstance = new BoosterInstance(booster);
        _activeBoosters.Add(boosterInstance);
        booster.OnAdded(this);
        BoosterAdded?.Invoke(boosterInstance);

    }

    public void RemoveBooster(Booster booster)
    {
        // aktif booster lar içinde gezilir
        // ilgili booster ýn kalan süresi 0 yapýlýr

        foreach (var instance in _activeBoosters)
        {
            if(instance.Booster == booster)
            {
                instance.RemainingDuration = 0;
            }
        }
    }
    private void Update()
    {
        // her frame bütün aktif booster larýn remaining time ýný azaltmamýz gerek
        // ters döngü yaptýk, çünkü düz döngüde bir eleman silindiðinde listenin eleman sýrasý bozulmuþ olur
        // bu þekilde hiç iþlem yapýlmayan elemanlar var olabilir
        
        for (int i = _activeBoosters.Count - 1; i >= 0;  i--)
        {
            // deltatime = iki frame arasý geçen süre

            var instance = _activeBoosters[i];
            instance.RemainingDuration -= Time.deltaTime;

            // eðer kalan süre 0 a eþit ya da 0 ýn altýna düþerse ilgili booster kaldýrýlýr ve active listinden çýkarýlýr
            if(instance.RemainingDuration <= 0 )
            {
                instance.Booster.OnRemoved(this);
                _activeBoosters.RemoveAt(i);
                BoosterRemoved?.Invoke(instance.Booster);
            }
        }
    }

    public class BoosterInstance
    {
        // bu sýnýfýn görevi bir booster eklendiði zaman booster ýn ne kadar zamanýnýn kaldýðýný tutmak
        
        public Booster Booster;

        public float RemainingDuration;


        public BoosterInstance(Booster booster)
        {
            Booster = booster;
            ResetDuration();
        }

        internal void ResetDuration()
        {
            RemainingDuration = Booster.Duration;
        }
    }
    
}
