using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipCorrect : MonoBehaviour
{
    //Movement Variables
    float xMovement;
    float yMovement;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int spawnRate = 10;

    //Camera boundry variables
    Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    //Objects
    [SerializeField] private GameObject meteorSmall;
    [SerializeField] private GameObject meteorBig;
    [SerializeField] private GameObject parent;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    void Update()
    {
        //Kazdy frame ukladame hracov input v X a Y smere do premennych
         xMovement = Input.GetAxisRaw("Horizontal");
         yMovement = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        //Zoberieme input hodnoty od hraca a vytvorime z nc
        Vector2 movementVector = new Vector2(xMovement, yMovement);
        
        movementVector = movementVector.normalized;
        Vector2 finalMovement = movementVector * speed * Time.fixedDeltaTime;
        
        //Kazdy Update v ktorom sa vykonava kalkulacia fyzikalnych vypoctov vykona hrac pohyb
        transform.Translate(finalMovement);

        //Meteor spawning
        var random = new System.Random();
        if (random.Next(spawnRate) == spawnRate - 1) SpawnMeteor();

    }
    private void LateUpdate()   
    {
        //Pozerame ci objekt nie je mimo kameru a nastavime ho tak aby nebol
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x*-1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y*-1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

    private void SpawnMeteor()
    {
        Debug.Log("Here");
        var random = new System.Random();
        float randomPosX = Random.Range(screenBounds.x * -1, screenBounds.x);
        float randomPosY = Random.Range(screenBounds.y, screenBounds.y + 4);

        Vector2 pos = new Vector3(randomPosX, randomPosY);
        if (random.Next(0, 8) == 0)
            Instantiate(meteorBig, pos, transform.rotation);
        else Instantiate(meteorSmall, pos, transform.rotation);

    }
}
