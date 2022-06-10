using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPF : MonoBehaviour
{
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float dragNum = 5;

    float movementX;
    bool isGrounded;
    bool isCharging;
    float chargeLevel = 5f;
    Rigidbody2D rb;
    float defaultSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundMask);

        movementX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) isCharging = true;
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            isCharging = false;
            Jump();
        }


    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, 0f);
        movement = movement.normalized;
        movement = movement * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        //Nabijanie skoku
        if (isCharging && chargeLevel < 12.5)
        {
            chargeLevel += 0.15f;
        } else if (isCharging)
        {
            isCharging = false;
            Jump();
        }

        //Gravity
        if (!isGrounded && rb.velocity.magnitude < 2f) rb.gravityScale = 2.8f;
        if (isGrounded)
        {
            rb.gravityScale = 1f;
            speed = defaultSpeed;
        }

        //Drag
        if (!isGrounded && speed != 0) speed -= dragNum/100;


    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, chargeLevel), ForceMode2D.Impulse);
        chargeLevel = 5f;
    }

}
