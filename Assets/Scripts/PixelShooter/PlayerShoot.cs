using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    float cooldown=0;
    public float maxCooldown = 3;

    public GameObject gun1;
    public GameObject gun2;

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0 && Input.GetKey(KeyCode.Space))
        {
            GameObject createdBullet1 = Instantiate(bullet);
            GameObject createdBullet2 = Instantiate(bullet);
            createdBullet1.transform.position = gun1.transform.position;
            createdBullet2.transform.position = gun2.transform.position;
            cooldown = maxCooldown;
        }
    }
}
