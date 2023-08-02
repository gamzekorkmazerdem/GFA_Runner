using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
    // toplanabilen nesneleri bu sýnýf üzerinden kalýtýmla üreteceðiz
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.CompareTag("Player"))
        {
            // eðer player nesneye çarpmýþsa toplama metodu çalýþsýn
            // ve toplanan nesne yok edilsin
            OnCollected();
            Destroy(gameObject);
        }
    }
    protected abstract void OnCollected();
}
