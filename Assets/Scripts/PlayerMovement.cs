using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");//Player yatay hareketleri için
        float verticalInput = Input.GetAxis("Vertical");//Player dikey hareketleri için

        //Player yön hareketlerini ve hızları
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        //Player Zıplaması
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();

        }

    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }
    void OnCollisionEnter(Collision collision)//Player EnemyHead ile temas ettiğinde Enemy Ölür.
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

}
