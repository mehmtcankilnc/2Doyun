using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField]private LayerMask jumpableGround;
    private float dirX=0f;
    public float moveSpeed =7f;
    public float jumpForce=14f;
    private enum MovementState{ idle,running,jumping,falling}
    private SpriteRenderer sprite;
    [SerializeField]private float climbSpeed=5f;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        coll=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(dirX*moveSpeed,rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        UpdateAnimationState();
    }
    void FixedUpdate()
    {
        if (anim.GetBool("climbing"))
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector2 climbVelocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
            rb.velocity = climbVelocity;
        }
    }

    private void UpdateAnimationState(){
        MovementState state;
        if(dirX > 0f){
            state=MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f){
            state=MovementState.running;
            sprite.flipX = true;
        }
        else{
            state=MovementState.idle;
        }
        if(rb.velocity.y > .1f){
            state=MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f){
            state=MovementState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Ladder")
        {
            anim.SetBool("climbing", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {   
        if (other.tag == "Ladder")
        {
            anim.SetBool("climbing", false);
        }
    }
}
