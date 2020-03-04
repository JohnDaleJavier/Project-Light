using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Rewired;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer sprite;
    public float playerHorizSpeed;
    public float playerVertSpeed;
    public bool canMove;
    private Vector2 direction;
    private Rigidbody2D body2D;
    private Animator anim;

    //Rewired stuff that we will DEFINITELY use but not now
    //public Player player;
    //public int playerId;

    void Start()
    {
        canMove = true;
        sprite = GetComponent<SpriteRenderer>();
        body2D = GetComponent <Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canMove)
        {
            direction.y = Input.GetAxisRaw("Vertical");
            direction.x = Input.GetAxisRaw("Horizontal");
        }

        //anim.SetBool("isMoving", true);
        //For when we have animations and shit
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                body2D.AddForce(new Vector2(direction.x * playerHorizSpeed, direction.y * playerVertSpeed));
            }
        }
    }

    
}
