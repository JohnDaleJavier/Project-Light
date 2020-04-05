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
                other.gameObject.GetComponent<PlayerMovement>().caughtInLight = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId != sharedData.currentMainPlayer)
            {
                print ("poop");
                other.gameObject.GetComponent<PlayerMovement>().caughtInLight = false;
            }
        }
    }
}
