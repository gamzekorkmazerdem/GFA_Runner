using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alttaki sat�r eklendi�inde bu scripti kullanan nesnelerde rigidbody kullan�lmas� zorunlu olur. 
//[RequireComponent(typeof(Rigidbody))]

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] // bu attribute ile ilgili de�i�ken inspector'dan de�i�tirilebilir demek
    private float _forwardSpeed; // public olursa encapsulation'a ayk�r�

    [SerializeField]
    private float _horizantalSpeed;

    [SerializeField]
    private Rigidbody _rigidBody;

    private Vector3 _velocity = new Vector3();

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("Hello world!");
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

        //Vector3 velocity = Vector3.forward * _forwardSpeed;

        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidBody.velocity.y;
        _velocity.x = Input.GetAxis("Horizontal") * _horizantalSpeed;

        //Debug.Log(Input.GetAxis("Horizontal"));

        // transform.position += velocity * Time.deltaTime;

    }

    // fizikle alakal� i�lemler fixedupdate ile yap�l�r
    private void FixedUpdate()
    {
        _rigidBody.velocity = _velocity;

    }
}
