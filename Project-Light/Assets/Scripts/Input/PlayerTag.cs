﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    public SharedData sharedData;
    public ScoreManager scoreManager;
    public PlayerMovement playerInput;
    Rigidbody2D body;


    void Start()
    {
        playerInput = GetComponent<PlayerMovement>();
        body = GetComponent<Rigidbody2D>();
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
        sharedData.pauseGame = true;
        
        //tell all ghosts to emote despawn and respawn at middle
        yield return new WaitForSeconds(5);
        sharedData.pauseGame = false;
    }
}
