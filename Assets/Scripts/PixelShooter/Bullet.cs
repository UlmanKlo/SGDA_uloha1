using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=10f;
    private void Start()
    {
        Destroy(this.gameObject,5f);
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(0,speed)*Time.fixedDeltaTime;
    }
}
