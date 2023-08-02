using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player")) //�arp��t���m�z objenin tag i player ise i�lem yap
        {
            //Destroy(collision.rigidbody);
            //Debug.Log("Collision Enter: " + collision.rigidbody.name);
            GameInstance.Instance.Lose();
        }
        else
        {
            // getcontact ile �arp��ma noktas�n�n normalini elde ederiz
            var normal = collision.GetContact(0).normal;

            // tek seferlik ivme vermek i�in impulse kullan�l�yor
            // �arpan cisim e�er player d���nda bir cisim ise o cisim yukar� do�ru u�sun dedik
            collision.rigidbody.AddForce(Vector3.up * 30, ForceMode.Impulse);
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    //Debug.Log(collision.rigidbody.name);
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    //Debug.Log(collision.rigidbody.name);
    //}

    //private void OnTriggerEnter(Collider collider)
    //{
        
    //}
    //private void OnTriggerExit(Collider collider)
    //{
        
    //}
    //private void OnTriggerStay(Collider collider)
    //{
        
    //}
}
