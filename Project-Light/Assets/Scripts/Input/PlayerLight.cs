using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerLight : MonoBehaviour
{
    // 0 being radius light 1 being flash light
    public Light[] lightSource;    
    public SharedData sharedData;
    PlayerMovement playerMovement;
    PlayerTag playerTag;
    Vector2 mousePosition;
    Player player;
    int playerID;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerID = playerMovement.playerId;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
