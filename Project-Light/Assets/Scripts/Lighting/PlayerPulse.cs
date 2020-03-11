using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerPulse : MonoBehaviour
{
    public float pulseDuration;
    public GameObject pulseLight;
    PlayerMovement playerMovement;
    int playerID;
    Player player;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent <PlayerMovement>();
        playerID = playerMovement.playerId;
        player = ReInput.players.GetPlayer(playerID);
        
    }

    private void Update()
    {
        if (player.GetButtonDown("Confirm"))
        {
            StartCoroutine(pulse());
        }
    }

    IEnumerator pulse()
    {
        pulseLight.SetActive(true);
        yield return new WaitForSeconds(pulseDuration);
        pulseLight.SetActive(false);
    }
}
