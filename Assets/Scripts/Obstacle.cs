using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player")) //�arp��t���m�z objenin tag i player ise i�lem yap
        {
            // nesneye yaln�zca geldi�imiz y�nden �arp�nca oyun bitsin
            // engellere yandan �arp�labilsin
            // bunun i�in a�a��daki i�lemler yap�lmal�
            // getcontact ile �arp��ma y�zeyinin normal vekt�r� bulunur
            var hitNormal = collision.GetContact(0).normal;

            // Dot vekt�r� verilen iki vekt�r�n nokta �arp�m�n� al�r
            // yani iki vekt�r�n ayn� y�ne bak�p bakmad���n� kontrol eder
            // e�er ayn� y�ne bak�yorlarsa 1, bakm�yorlarsa -1 d�nd�r�r

            var hitDot = Vector3.Dot(hitNormal, Vector3.forward);
            
            // tam e�itlik kontrol� yap�lmamal�
            // ��nk� dot i�lemi yap�l�yor
            // float ile yap�lan i�lemlerde otomatik yuvarlama yap�labilir
            // bu durumda istenen tam e�itlik sa�lanamayabilir 
            if(hitDot > 0.99f)
            {
                GameInstance.Instance.Lose();
            }

            
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
