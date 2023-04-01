using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToPoint : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;

    public float speed = 5f;

    private Vector2 targetPoint;
    private float distance;
    void Start()
    {
        targetPoint = endPoint;
        distance = Vector2.Distance(startPoint, endPoint);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            targetPoint = targetPoint == endPoint ? startPoint : endPoint;
            Vector2 direction = (targetPoint - (Vector2)transform.position).normalized;
            transform.right = direction;
        }
        
    }
}
