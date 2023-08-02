using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player")) //çarpýþtýðýmýz objenin tag i player ise iþlem yap
        {
            //Destroy(collision.rigidbody);
            //Debug.Log("Collision Enter: " + collision.rigidbody.name);
            GameInstance.Instance.Lose();
        }
        else
        {
            // getcontact ile çarpýþma noktasýnýn normalini elde ederiz
            var normal = collision.GetContact(0).normal;

            // tek seferlik ivme vermek için impulse kullanýlýyor
            // çarpan cisim eðer player dýþýnda bir cisim ise o cisim yukarý doðru uçsun dedik
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
