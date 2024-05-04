using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Isalive = true;
    public float Runspeed;
    public float Horizontalspeed;
    public Rigidbody rb;
    float HorizontalInput;
    public float VerticalInput;
    [SerializeField] private float jumpforce = 350;
    [SerializeField] private LayerMask GroundMask;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (Isalive)
        {
            Vector3 forwardmovment = transform.forward *VerticalInput * Runspeed * Time.fixedDeltaTime;
            Vector3 horizontalMovment = transform.right * HorizontalInput * Horizontalspeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardmovment + horizontalMovment);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal"); 
        VerticalInput = Input.GetAxis("Vertical");
        float playerheight =GetComponent<Collider>().bounds.size.y;
        bool Isground = Physics.Raycast(transform.position, Vector3.down, (playerheight / 2) + 0.1f, GroundMask);
        if (Input.GetKeyDown(KeyCode.Space)&&Isalive==true&&Isground==true) {
            jump();

        }
    }
    public void jump()
    {
        rb.AddForce(Vector3.up * jumpforce);
    }
}
