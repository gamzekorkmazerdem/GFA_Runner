using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] // bu attribute ile ilgili deðiþken inspector'dan deðiþtirilebilir demek
    private float _forwardSpeed; // public olursa encapsulation'a aykýrý
    [SerializeField]
    private float _horizantalSpeed;



    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    private void Update()
    {
        // GetComponent<Transform>() = transform;

        // karakter her frame'de 1 birim ileri gider
        // Eðer fps = 60 => Time.deltaTime == 0.016f;
        // Eðer fps = 30 => Time.deltaTime == 0.032f;
        // eðer vektörü deltatime ile çarparsak fps ne olursa olsun karakter verdiðimiz vektör kadar hareket eder
        // Vector3.forward = Vector3(0,0,1)

        /*
        if (Input.GetKeyDown(KeyCode.A))
        A ya basýldýðý sürece 1 döner
        
         */

        Vector3 velocity = Vector3.forward * _forwardSpeed;
        
        velocity.z = _forwardSpeed;
        velocity.x = Input.GetAxis("Horizontal") * _horizantalSpeed;

        //Debug.Log(Input.GetAxis("Horizontal"));

        transform.position += velocity * Time.deltaTime;







    }
}
