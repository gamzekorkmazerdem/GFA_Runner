using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alttaki satýr eklendiðinde bu scripti kullanan nesnelerde rigidbody kullanýlmasý zorunlu olur. 
//[RequireComponent(typeof(Rigidbody))]

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] // bu attribute ile ilgili deðiþken inspector'dan deðiþtirilebilir demek
    private float _forwardSpeed; // public olursa encapsulation'a aykýrý

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
        // Eðer fps = 60 => Time.deltaTime == 0.016f;
        // Eðer fps = 30 => Time.deltaTime == 0.032f;
        // eðer vektörü deltatime ile çarparsak fps ne olursa olsun karakter verdiðimiz vektör kadar hareket eder
        // Vector3.forward = Vector3(0,0,1)

        /*
        if (Input.GetKeyDown(KeyCode.A))
        A ya basýldýðý sürece 1 döner
        
         */

        //Vector3 velocity = Vector3.forward * _forwardSpeed;

        _velocity.z = _forwardSpeed;
        _velocity.y = _rigidBody.velocity.y;
        _velocity.x = Input.GetAxis("Horizontal") * _horizantalSpeed;

        //Debug.Log(Input.GetAxis("Horizontal"));

        // transform.position += velocity * Time.deltaTime;

        // space e basýldýðý anda ve zemindeysek karakterin zýplamasý için yapýlacak iþlemler
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            // burada inputla alakalý iþlem yapýldý
            // bu tek seferlik çalýþacak bir durum
            // rigidbody kullansak da bu sebeple fixedupdate e deðil update e yazdýk

            _rigidBody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isGrounded = false;
        }

    }

    // fizikle alakalý iþlemler fixedupdate ile yapýlýr
    private void FixedUpdate()
    {

        // player ýn gidebileceði alaný kýsýtlamak için kontrol yapýlýr
        // eðer player ýn bulunduðu x konumu max distance dan fazlaya
        // clamp ile player ýn bulunduðu x konumu kýsýtlanarak -max +max arasýna çekilir 

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
