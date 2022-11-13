using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    private void Move(Vector2 direction2)
    {
        distance = Vector2.Distance(transform.position, player.transform.position); //find distance between of enemy from the player
        Vector2 direction = player.transform.position - transform.position; //locate the direction of the player
        direction.Normalize(); //make enemy only move in 1's

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.position += (Vector3)direction2;
    }

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
        Move(transform.position);
    }

    //transform.position += (Vector3) direction;

}
