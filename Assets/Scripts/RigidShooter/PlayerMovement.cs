using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidBody2D;
    public float speed = 2f;
    public float rotationSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody2D.AddForce(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody2D.AddForce(transform.up * 3* speed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += Vector3.forward *rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime;
        }

    }
}
