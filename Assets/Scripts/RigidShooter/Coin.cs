using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector2 screenBounds;
    [SerializeField] private LayerMask mMask;
    //Fungovalo, ale prestalo a neviem ani preco

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            float randomPosX;
            float randomPosY;
            Vector2 newPos;

            randomPosX = Random.Range(-screenBounds.x, screenBounds.x);
            randomPosY = Random.Range(-screenBounds.y, screenBounds.y);
            newPos = new Vector2(randomPosX, randomPosY);
            if (!Physics2D.OverlapCircle(transform.position, 1.85f, mMask))
            {
                transform.position = newPos;
            }
            else transform.position = Vector2.zero;
            
        }   
    }
}



