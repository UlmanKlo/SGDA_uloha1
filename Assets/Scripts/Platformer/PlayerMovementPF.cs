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
    Rigidbody2D rb;
    float defaultSpeed;
    int count;
    bool startTiming;


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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) startTiming = true;
        if (Input.GetKeyUp(KeyCode.Space)) startTiming = false;
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, 0f);
        movement = movement.normalized;
        movement = movement * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        //Gravity
        if (!isGrounded && rb.velocity.magnitude < 0.5f) rb.gravityScale = 2.8f;
        if (isGrounded)
        {
            rb.gravityScale = 1f;
            speed = defaultSpeed;
        }

        //Drag
        if (!isGrounded && speed != 0) speed -= dragNum/100;


        //Jump
        if (count > 10 && isGrounded)
        {
            BigJump();
        }
        else if (!startTiming && 0 < count && count <= 18) Jump();

        //Timing
        if (startTiming) Timing();
        else count = 0;


    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, 8.5f), ForceMode2D.Impulse);
    }

    private void BigJump()
    {
        rb.AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
    }

    private void Timing()
    {
        count++;
    }
}
