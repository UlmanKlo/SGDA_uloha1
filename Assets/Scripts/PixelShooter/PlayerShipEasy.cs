using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipEasy : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed);
        }
    }


}
