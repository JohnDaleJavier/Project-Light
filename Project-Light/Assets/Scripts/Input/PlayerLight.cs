using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerLight : MonoBehaviour
{
    // 0 being radius light 1 being flash light
    public GameObject flashLightSource;
    public GameObject flashLightCollider;
    public SharedData sharedData;
    PlayerMovement playerMovement;


    Player player;
    int playerID;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerID = playerMovement.playerId;
        player = ReInput.players.GetPlayer(playerID);
    }

    // Update is called once per frame
    void Update()
    {


        //https://answers.unity.com/questions/630670/rotate-2d-sprite-towards-moving-direction.html
        
        float directional = (Mathf.Atan2(player.GetAxisRaw("VerticalInspect"), player.GetAxisRaw("HorizontalInspect")) * Mathf.Rad2Deg) - 90;

        Quaternion rotation = Quaternion.AngleAxis(directional, transform.forward);
        if (player.GetAxisRaw("VerticalInspect") != 0 && player.GetAxisRaw("HorizontalInspect") != 0)
        {
            flashLightSource.transform.rotation = rotation;
            
        }
    }

}
