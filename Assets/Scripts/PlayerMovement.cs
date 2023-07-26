using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] // bu attribute ile ilgili de�i�ken inspector'dan de�i�tirilebilir demek
    private float _forwardSpeed; // public olursa encapsulation'a ayk�r�
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
        // E�er fps = 60 => Time.deltaTime == 0.016f;
        // E�er fps = 30 => Time.deltaTime == 0.032f;
        // e�er vekt�r� deltatime ile �arparsak fps ne olursa olsun karakter verdi�imiz vekt�r kadar hareket eder
        // Vector3.forward = Vector3(0,0,1)

        /*
        if (Input.GetKeyDown(KeyCode.A))
        A ya bas�ld��� s�rece 1 d�ner
        
         */

        Vector3 velocity = Vector3.forward * _forwardSpeed;
        
        velocity.z = _forwardSpeed;
        velocity.x = Input.GetAxis("Horizontal") * _horizantalSpeed;

        //Debug.Log(Input.GetAxis("Horizontal"));

        transform.position += velocity * Time.deltaTime;







    }
}
