using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector2 screenBounds;
    //Fungovalo, ale prestalo a neviem ani preco

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float randomPosX = Random.Range(-screenBounds.x, screenBounds.x);
            float randomPosY = Random.Range(-screenBounds.y, screenBounds.y);
            Vector2 newPos = new Vector2(randomPosX, randomPosY);
            transform.position = newPos;
        }
    }
}



