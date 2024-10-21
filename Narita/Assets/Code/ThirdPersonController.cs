using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    //para guardar el input en update y usarlo en FixedUpdate
    private Vector3 input;
    private Rigidbody _rb;
    public float rotationSpeed = 300f;
    public float camXRot = 0f;//Rotacion de la camara en x
    private Camera _camera;
    public float jumpForce = 300f;
    public bool isGrounded = true;
    //El pivote de la camara tiene que rotar en el eje X
    public Transform cameraPivot;

    [Header("GROUND CHEKER")]
    public Transform groundCheckCenter;
    public Vector3 groundCheckSize = Vector3.one;
    //Para guardar los colliders que detecta el ground checker
    public Collider[] detectedColliders;
    //Para que el ground checker solo detecte la layer que nos interesa (Ground)
    //Asi no detectara al Player ni otros objetos que estorban
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //buscamos la camara en los objetos hijos y la asignamos
        _camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        //Guardamos el input para usarlo en FixedUpdate
        input = new Vector3(_horizontal, 0f, _vertical);
        //Para que se mueva en la direccion correcta respecto hacia donde mira, 
        //hay que transformar el input para  que sea en espacio local y no en espacio global
        input = transform.TransformDirection(input);

        //para girar en el eje Y
        float _rotMouseX = Input.GetAxisRaw("Mouse X");

        //float _rotMouseY = Input.GetAxisRaw("Mouse Y"); para rotar en el eje y hay que hacerlo con la camara
        transform.Rotate(0, _rotMouseX * rotationSpeed * Time.deltaTime, 0);
        //Se acumula el valor de la rotacion en X de la camara
        //para que aumente o disminuya conforme movemos el raton arriba y abajo
        camXRot -= Input.GetAxisRaw("Mouse Y") * rotationSpeed * Time.deltaTime;
        camXRot = Mathf.Clamp(camXRot, -60, 60);
        //Asignamos la rotacion en x a los angulos de la camara
        cameraPivot.localEulerAngles = new Vector3(camXRot, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _rb.AddForce(Vector3.up * jumpForce);
        }
        GroundCheck();
    }
    private void FixedUpdate()
    {
        //no usar input en fixedupdate
        //Hay que normalizar el input para que no se mueva mas rapido en diagonal
        Vector3 _velocity = input.normalized * moveSpeed;
        //No podemor modificar la cvelocity en el eje Y del rigibody, o caera muy despacio
        _velocity.y = _rb.velocity.y;
        _rb.velocity = _velocity;

    }
    void GroundCheck()
    {
        //Guardamos la variable todos los colliders que encuentre el overlap
        detectedColliders = Physics.OverlapBox(groundCheckCenter.position, groundCheckSize * 0.5f, Quaternion.Euler(0, 0, 0), groundLayer);
        //Cuando el checker detecte la menos un objeto suelo, podemos saltar
        if (detectedColliders.Length > 0)
        {
            isGrounded = true;
        }
        else //Cuando no haya ningun objeto detectado, ya estaremos en el aire
            isGrounded = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(groundCheckCenter.position, groundCheckSize);
    }
}
