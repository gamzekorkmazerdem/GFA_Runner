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

    [SerializeField]
    private float _jumpPower;

    private bool _isGrounded;

    [SerializeField]
    private float _maxHorizontalDistance;

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
        // GetComponent<Transform>() == transform;

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

        // space e bas�ld��� anda ve zemindeysek karakterin z�plamas� i�in yap�lacak i�lemler
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            // burada inputla alakal� i�lem yap�ld�
            // bu tek seferlik �al��acak bir durum
            // rigidbody kullansak da bu sebeple fixedupdate e de�il update e yazd�k

            _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }

    }

    // fizikle alakal� i�lemler fixedupdate ile yap�l�r
    private void FixedUpdate()
    {

        // player �n gidebilece�i alan� k�s�tlamak i�in kontrol yap�l�r
        // e�er player �n bulundu�u x konumu max distance dan fazlaya
        // clamp ile player �n bulundu�u x konumu k�s�tlanarak -max +max aras�na �ekilir 

        if (Mathf.Abs(_rigidBody.position.x) > _maxHorizontalDistance)
        {
            var clampedPosition = _rigidBody.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_maxHorizontalDistance, _maxHorizontalDistance);
        
            _rigidBody.position = clampedPosition;
            _velocity.x = 0;
        }

        _rigidBody.velocity = _velocity;


        Debug.DrawRay(_rigidBody.position, Vector3.down * 1.05f);
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.05f);
        

        
    }
}
