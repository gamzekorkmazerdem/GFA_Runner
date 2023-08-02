using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
    // toplanabilen nesneleri bu s�n�f �zerinden kal�t�mla �retece�iz
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody.CompareTag("Player"))
        {
            // e�er player nesneye �arpm��sa toplama metodu �al��s�n
            // ve toplanan nesne yok edilsin
            OnCollected();
            Destroy(gameObject);
        }
    }
    protected abstract void OnCollected();
}
