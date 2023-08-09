using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterContainer : MonoBehaviour
{
    /*
     * Bu s�n�f�n g�revi eklenen booster lar�n ya�am d�ng�s�n� kontrol etmek 
     * booster lar buraya eklenecek ve i�i bitti�inde kald�r�lacak
     * 
     */
    public List<BoosterInstance> _activeBoosters = new List<BoosterInstance>();

    public event Action<BoosterInstance> BoosterAdded;
    public event Action<Booster> BoosterRemoved;

    public void AddBooster(Booster booster)
    {
        // b�t�n aktif booster lar kontrol edilir.
        // e�er daha �nce eklenmi� bir boostersa duration time � resetlenir
        // yani 10 sn ise tekrar 10 sn atan�r
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
        // aktif booster lar i�inde gezilir
        // ilgili booster �n kalan s�resi 0 yap�l�r

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
        // her frame b�t�n aktif booster lar�n remaining time �n� azaltmam�z gerek
        // ters d�ng� yapt�k, ��nk� d�z d�ng�de bir eleman silindi�inde listenin eleman s�ras� bozulmu� olur
        // bu �ekilde hi� i�lem yap�lmayan elemanlar var olabilir
        
        for (int i = _activeBoosters.Count - 1; i >= 0;  i--)
        {
            // deltatime = iki frame aras� ge�en s�re

            var instance = _activeBoosters[i];
            instance.RemainingDuration -= Time.deltaTime;

            // e�er kalan s�re 0 a e�it ya da 0 �n alt�na d��erse ilgili booster kald�r�l�r ve active listinden ��kar�l�r
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
        // bu s�n�f�n g�revi bir booster eklendi�i zaman booster �n ne kadar zaman�n�n kald���n� tutmak
        
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
