using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public float Speed = 10;
 
    [SerializeField] private bool _isGrounded = true;
    private Rigidbody rb;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        
    }
    
    private void OnCollisionEnter(Collision pCollision)
    {
        if(pCollision.gameObject.transform.CompareTag("Player"))
        {
            _isGrounded = true;
        }
    }

    private void Move()
    {
        
        float x = 0;
        float z = 0;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        
        Vector3 move = (transform.right * x + transform.forward * z) * Speed;
        move.y = rb.linearVelocity.y;
        transform.forward = move;
        rb.linearVelocity = move;
        print(move);
        
        Vector3 direction = new Vector3(x * Speed, rb.linearVelocity.y, z * Speed);
        //transform.position += move * Speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 18, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
}
