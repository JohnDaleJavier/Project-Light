using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    PlayerMovement playerInput;
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
            print("fuck" + other.gameObject.GetComponent<PlayerMovement>().playerId.ToString());
        }
    }
}
