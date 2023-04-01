using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{   
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 5f;
    private Vector2 targetPoint;
    private bool idle = true;
    private Transform playerPosition;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private Transform startPosition;
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        targetPoint = endPoint;
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        startPosition = GetComponent<Transform>();
    }
    private void Update(){
        if(idle){
                transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
            {
                targetPoint = targetPoint == endPoint ? startPoint : endPoint;
                Vector2 direction = (targetPoint - (Vector2)transform.position).normalized;
                transform.right = -direction;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            idle = false;
            anim.SetBool("attacking",true);
            Vector2 target = (playerPosition.position - transform.position).normalized;
            rb.velocity = target * speed;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            anim.SetBool("attacking",false);
            Vector2 toStart = (startPosition.position - transform.position).normalized;
            rb.velocity = toStart * speed;
            idle = true;
        }
    }
}
