using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttractor : MonoBehaviour
{
    // etrafýndaki bütün altýnlarý tespit edecek ve çekecek

    public float Radius { get; set; } = 10;
    private void FixedUpdate()
    {
        // overlapsphere nesnenin collider ýna giren bütün collider larý tespit eder
        // trigger olan nesneleri de algýlamasý için QueryTriggerInteraction kullanýlmalý
        // layermask: ilgili layer da bulunan nesnelerin görmezden gelinmesini saðlar
        // LayerMask.GetMask("Default") ile bütün layerlardaki tüm nesneleri algýla diyoruz
        var collidersInRange = Physics.OverlapSphere(transform.position, Radius, LayerMask.GetMask("Default"),QueryTriggerInteraction.Collide);

        foreach (var collider in collidersInRange)
        {
            if (!collider.isTrigger) continue;

            if(collider.TryGetComponent<Gold>(out var _)) // "_" boþ isim demek. burada gold var mý yok mu diye kontrol ediyoruz
            {
                var follower = collider.gameObject.AddComponent<MagnetFollower>();
                follower.Target = transform;
            }
        }

    }
}
