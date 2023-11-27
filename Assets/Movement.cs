using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] const float JUMPFORCE = 500.0f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;

    public GameObject pinPrefab; 
    public float shootingSpeed = 10f; 
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (Input.GetButtonDown("Fire1")) 
        {
            ShootPin();
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * SPEED, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
        {
            Flip();
        }
        if (jumpPressed && isGrounded)
            Jump();
    }

    void Flip()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, JUMPFORCE));
        jumpPressed = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumpPressed = false;
        }
    }

    void ShootPin()
    {
        Vector3 playerPosition = transform.position; // Get the player's position
        GameObject pin = Instantiate(pinPrefab, playerPosition, Quaternion.identity);

        // Calculate the shooting direction based on player's facing direction
        Vector3 shootingDirection = isFacingRight ? Vector3.right : Vector3.left;

        PinMovement pinMovement = pin.GetComponent<PinMovement>();
        if (pinMovement != null)
        {
            pinMovement.SetShootDirection(shootingDirection);
        }
    }
    public void Respawn()
    {
    transform.position = initialPosition;
    }

}
