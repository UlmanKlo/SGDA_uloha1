using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidBody2D;
    public float speed = 2f;
    public float rotationSpeed = 2f;
    Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
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

        //Boundaries
        if (transform.position.x - 0.4f < -screenBounds.x || transform.position.x + 0.4f > screenBounds.x) rigidBody2D.velocity = Vector3.zero;
        if (transform.position.y - 0.4f < -screenBounds.y || transform.position.y + 0.4f > screenBounds.y) rigidBody2D.velocity = Vector3.zero;



    }
}
