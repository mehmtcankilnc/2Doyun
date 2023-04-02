using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public int destinationPoint;
    void FixedUpdate()
    {
        if(destinationPoint == 0){
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[0].position) < .1f){
                transform.localScale = new Vector3(-1f,1f,1f);
                destinationPoint = 1;
            }
        }
        if(destinationPoint == 1){
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, points[1].position) < .1f){
                transform.localScale = new Vector3(1f,1f,1f);
                destinationPoint = 0;
            }
        }
    }
}
