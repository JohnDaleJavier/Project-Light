using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    public SharedData sharedData;
    SpriteRenderer sprite;
    Vector2 direction;
    Rigidbody2D body2D;
    Animator anim;
    PlayerTag playerTag;
    PlayerLight playerLight;

    Vector2 startPosition;
    public float playerHorizSpeed;
    public float playerVertSpeed;
    public float maxSpeed;

    public bool canMove;
    
    Player player;
    public int playerId;

    void Start()
    {
        canMove = true;
        player = ReInput.players.GetPlayer(playerId);
        sprite = GetComponent<SpriteRenderer>();
        body2D = GetComponent <Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTag = GetComponent<PlayerTag>();
        playerLight = GetComponent<PlayerLight>();
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        if (sharedData.currentMainPlayer == playerId)
        {
            playerTag.enabled = false;
            playerLight.enabled = true;
        }else if(sharedData.currentMainPlayer != playerId)
        {
            playerTag.enabled = true;
            playerLight.enabled = false;
        }
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
        if (canMove && sharedData.pauseGame == false)
        {
            
            if (player.GetAxisRaw("HorizontalMovement") != 0 || player.GetAxisRaw("VerticalMovement") != 0)
            {
                body2D.velocity = new Vector2 (player.GetAxisRaw("HorizontalMovement") * playerHorizSpeed, player.GetAxisRaw("VerticalMovement") * playerVertSpeed);
/*                body2D.AddForce(new Vector2((direction.x +.03f) * playerHorizSpeed, direction.y * playerVertSpeed));
                if(body2D.velocity.x >= maxSpeed){
                    body2D.velocity = new Vector2(maxSpeed, body2D.velocity.y);
                }
                if(body2D.velocity.y >= maxSpeed){
                    body2D.velocity = new Vector2(body2D.velocity.x, maxSpeed);
                }*/
            }
            else{
                body2D.velocity = new Vector2(0f,0f);
            }
        }
        else
        {
            body2D.velocity = new Vector2(0f, 0f);
        }
    }

    public void PlayerRestart()
    {
        transform.position = startPosition; 
    }
}
