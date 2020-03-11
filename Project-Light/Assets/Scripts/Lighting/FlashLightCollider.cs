using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightCollider : MonoBehaviour
{
    public SharedData sharedData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId != sharedData.currentMainPlayer)
            {
                print ("AGHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");

            }
            //StartCoroutine(Tagged());
            //scoreManager.AddScoreTag(other.gameObject.GetComponent<PlayerMovement>().playerId);
            //scoreManager.SubtractScoreTag(playerInput.playerId);
        }
    }
}
