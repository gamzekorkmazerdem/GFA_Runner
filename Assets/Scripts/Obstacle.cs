using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player")) //çarpýþtýðýmýz objenin tag i player ise iþlem yap
        {
            // nesneye yalnýzca geldiðimiz yönden çarpýnca oyun bitsin
            // engellere yandan çarpýlabilsin
            // bunun için aþaðýdaki iþlemler yapýlmalý
            // getcontact ile çarpýþma yüzeyinin normal vektörü bulunur
            var hitNormal = collision.GetContact(0).normal;

            // Dot vektörü verilen iki vektörün nokta çarpýmýný alýr
            // yani iki vektörün ayný yöne bakýp bakmadýðýný kontrol eder
            // eðer ayný yöne bakýyorlarsa 1, bakmýyorlarsa -1 döndürür

            var hitDot = Vector3.Dot(hitNormal, Vector3.forward);
            
            // tam eþitlik kontrolü yapýlmamalý
            // çünkü dot iþlemi yapýlýyor
            // float ile yapýlan iþlemlerde otomatik yuvarlama yapýlabilir
            // bu durumda istenen tam eþitlik saðlanamayabilir 
            if(hitDot > 0.99f)
            {
                GameInstance.Instance.Lose();
            }

            
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
