using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed;
    public Transform playerLocation;
    Vector2 movement;

    public int size;

    private float distance;

    private void Start()
    {
        //playerLocation = player.transform.position    
    }

    private void Move(Vector2 direction2)
    {
        //distance = Vector2.Distance(transform.position, player.transform.position); //find distance between of enemy from the player
        //Vector2 direction = player.transform.position - transform.position; //locate the direction of the player
        //direction.Normalize(); //make enemy only move in 1's

        //if (movement.x != 0)
        //{
        //    //transform.position;
        //    enemy.transform.position += 128f;

        //}


        //var step = speed * Time.deltaTime;

        //var zIndex = transform.position.z;
        //enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, step);
        //enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, zIndex);

        //if(Vector2.Distance(enemy.transform.position, player.transform.position) < 0.0001f)
        //{
        //    //PositionCharacteronTile();
        //}

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.position += (Vector3)direction2;
    }

    //private void PositionCharacteronTile(RoughTile tile)
    //{
    //    enemy.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
    //    enemy.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
    //}

    //private IEnumerator MovePlayer(Vector3 direction)
    //{
    //    isMoving = true;

    //    float elapsedTime = 0;

    //    origPos = transform.position;
    //    targetPos = origPos + direction;

    //    while 
    //}

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        //Move(transform.position);

        distance = Vector2.Distance(transform.position, player.transform.position); //find distance between of enemy from the player
        Vector2 direction = player.transform.position - transform.position; //locate the direction of the player
        direction.Normalize(); //make enemy only move in 1's

        //if (direction.x != 0)
        //{
        //    //transform.position;
        //    pos.x += 1f;
        //    //Vector2 direction = player.transform.position - transform.position;
        //}

        //if (direction.y != 0)
        //{
        //    pos.y += 1f;
        //}

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        if (direction.x > 5 && direction.x < 5.5)
        {
            direction.x = 5;
        }
        else if (direction.x > 5.5 && direction.x < 6)
        {
            direction.x = 5;
        }
        //transform.position += (Vector3) direction;
    }
}   