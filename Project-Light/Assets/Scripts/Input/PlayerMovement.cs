using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    //Gathered Scripts
    public SharedData sharedData;
    SpriteRenderer sprite;
    Vector2 direction;
    Rigidbody2D body2D;
    Animator anim;
    PlayerTag playerTag;
    PlayerLight playerLight;

    //respawn
    Vector2 startPosition;

    //values
    public float playerHorizSpeed;
    float playerHorizSpeedHold;
    public float playerVertSpeed;
    float playerVertSpeedHold;
    public float maxSpeed;

    public float deathTimer = 5;
    float deathTimerHold;

    //bools
    public bool canMove;
    public bool caughtInLight;
    
    //rewired
    Player player;
    public int playerId;

    void Start()
    {
        canMove = true;

        //used for respawn
        startPosition = new Vector3(this.transform.position.x, this.transform.position.y, 0f);

        //gather componenets
        player = ReInput.players.GetPlayer(playerId);
        sprite = GetComponent<SpriteRenderer>();
        body2D = GetComponent <Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerTag = GetComponent<PlayerTag>();
        playerLight = GetComponent<PlayerLight>();
        

        // value holds
        playerHorizSpeedHold = playerHorizSpeed;
        playerVertSpeedHold = playerVertSpeed;
        deathTimerHold = deathTimer;

        //If we want to implement changing main player mid game
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
            direction.y = player.GetAxisRaw("VerticalMovement");
            direction.x = player.GetAxisRaw("HorizontalMovement");

            if(direction.x != 0){
                anim.SetBool("playerMovement", true);
            }
            else{
                anim.SetBool("playerMovement", false);
            }
            
            Flip();

        }
        // Slow then kill if standing in light for too long
        if(caughtInLight && sharedData.pauseGame == false){
            playerHorizSpeed = playerHorizSpeedHold - (playerHorizSpeedHold * .4f);
            playerVertSpeed = playerVertSpeedHold - (playerVertSpeedHold * .4f);
            deathTimer -= Time.deltaTime;
            //print(playerHorizSpeed.ToString() +" "+ playerVertSpeed.ToString());
            if(deathTimer <= 0){
                StartCoroutine(Death());
            }
        }
        else if(!caughtInLight){
            playerHorizSpeed = playerHorizSpeedHold;
            playerVertSpeed = playerVertSpeedHold;
            //print(deathTimer.ToString());
            deathTimer = deathTimerHold;
            //print(playerHorizSpeed.ToString() +" "+ playerVertSpeed.ToString());
        }
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

    void Flip()
    {
        if (direction.x > 0)
        {
            
                sprite.flipX = false;
        }
            else if (direction.x <= 0)
            {
                sprite.flipX = true;
            }
        
    }

    public IEnumerator Death(){
        // stop everything Die Respawn wait 1 second
        anim.SetBool("Death",true);
        canMove = false;
        yield return new WaitForSeconds(2);
        anim.SetBool("Death",false);
        transform.position = startPosition;
        canMove = true;

    }

}
