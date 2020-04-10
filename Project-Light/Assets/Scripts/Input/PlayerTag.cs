using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    public SharedData sharedData;
    public ScoreManager scoreManager;
    public PlayerMovement playerInput;
    Rigidbody2D body;
    public AudioSource audi;
    public AudioClip deathSound;


    void Start()
    {
        playerInput = GetComponent<PlayerMovement>();
        body = GetComponent<Rigidbody2D>();
        //audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if(other.gameObject.GetComponent<PlayerMovement>().playerId == sharedData.currentMainPlayer) { 
            StartCoroutine(Tagged());       
            scoreManager.AddScoreTag(playerInput.playerId);
            scoreManager.SubtractScoreTag(sharedData.currentMainPlayer);
            }
        }
    }
    public IEnumerator Tagged()
    {
        sharedData.respawnAll = true;
        sharedData.pauseGame = true;
        
        audi.PlayOneShot(deathSound, 1f);
        //tell all ghosts to emote despawn and respawn at middle
        yield return new WaitForSeconds(5);
        sharedData.pauseGame = false;
        sharedData.respawnAll = false;
    }
}
