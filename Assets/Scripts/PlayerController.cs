using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Isalive = true;
    public float Runspeed;
    public float Horizontalspeed;
    public Rigidbody rb;
    float HorizontalInput;
    public float VerticalInput;
    public float IncreaseSpeed;
    [SerializeField] private float jumpforce = 100;
    [SerializeField] private LayerMask GroundMask;
    private float startYPosition;
    bool isJumping = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startYPosition = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (Isalive)
        {
            Vector3 forwardmovment = transform.forward * Runspeed * Time.fixedDeltaTime;
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
        float playerheight = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerheight / 2) + 0.1f, GroundMask);

        // If the player is not on the ground and is alive, and the Y position has decreased significantly from the start
        if (!isGrounded && Isalive && transform.position.y < startYPosition)
        {
            /*SoundManager.stopSound();
            SoundManager.playSound("Over");*/
            Dead();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Isalive && isGrounded && !isJumping)
        {
            jump();
            isJumping = true;
        }
    }


    public void jump()
    {
        rb.AddForce(Vector3.up * jumpforce);
        SoundManager.playSound("Jump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            isJumping = false;
        

        if (collision.gameObject.name == "graphic" || collision.gameObject.name == "Enemy" || collision.gameObject.tag == "obs")
        {
            /*SoundManager.stopSound();
            SoundManager.playSound("Over");*/
           
            Dead();

        }
        if (collision.gameObject.name == "coin(Clone)")
        {
            SoundManager.playSound("Coin");
            Destroy(collision.gameObject);
            GameManager.Instance.score++;
            Runspeed += IncreaseSpeed;
        }
    }

    private void Dead()
    {
        Isalive = false;
        SoundManager.stopSound(); // Stop the normal sound
        SoundManager.playSound("Over"); // Play the game over sound
        PlayerController.Destroy(this);
        GameManager.Instance.gameOver.SetActive(true);
    }
}
