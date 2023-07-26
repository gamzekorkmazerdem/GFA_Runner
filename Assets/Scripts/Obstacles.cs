using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            Destroy(collision.rigidbody);
            Debug.Log("Collision Enter: " + collision.rigidbody.name);
        }
        else
        {
            var normal = collision.GetContact(0).normal;
            // çarptýðýnda uçmasý için impulse kullanýlýyor
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
