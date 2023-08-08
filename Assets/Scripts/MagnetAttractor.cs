using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttractor : MonoBehaviour
{
    // etraf�ndaki b�t�n alt�nlar� tespit edecek ve �ekecek

    public float Radius { get; set; } = 10;
    private void FixedUpdate()
    {
        // overlapsphere nesnenin collider �na giren b�t�n collider lar� tespit eder
        // trigger olan nesneleri de alg�lamas� i�in QueryTriggerInteraction kullan�lmal�
        // layermask: ilgili layer da bulunan nesnelerin g�rmezden gelinmesini sa�lar
        // LayerMask.GetMask("Default") ile b�t�n layerlardaki t�m nesneleri alg�la diyoruz
        var collidersInRange = Physics.OverlapSphere(transform.position, Radius, LayerMask.GetMask("Default"),QueryTriggerInteraction.Collide);

        foreach (var collider in collidersInRange)
        {
            if (!collider.isTrigger) continue;

            if(collider.TryGetComponent<Gold>(out var _)) // "_" bo� isim demek. burada gold var m� yok mu diye kontrol ediyoruz
            {
                var follower = collider.gameObject.AddComponent<MagnetFollower>();
                follower.Target = transform;
            }
        }

    }
}
