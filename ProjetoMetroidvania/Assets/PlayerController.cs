using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    float movementX;
    float movementY;
    public float speed = 2;

    public SpriteRenderer spritePlayer;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FlipSprite(){
        if(movementX<0){
            spritePlayer.flipX = true;
        }
        if(movementX>0){
            spritePlayer.flipX = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        FlipSprite();
        animator.SetFloat("velocityX",Math.Abs(rb.linearVelocityX));
        Vector2 movement = new Vector2(movementX,0);
        rb.AddForce(movement*speed);
    }


}
