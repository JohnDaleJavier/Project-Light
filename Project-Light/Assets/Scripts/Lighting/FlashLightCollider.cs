using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightCollider : MonoBehaviour
{
    public SharedData sharedData;
    AudioSource audi;
    public AudioClip burnAudi;

    bool notCasted;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId != sharedData.currentMainPlayer)
            {
                if(notCasted){
                    audi.PlayOneShot(burnAudi,.5f);
                    notCasted = false;
                }
                
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId != sharedData.currentMainPlayer)
            {
                //audi.Play();
                other.gameObject.GetComponent<PlayerMovement>().caughtInLight = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId != sharedData.currentMainPlayer)
            {
                audi.Stop();
                notCasted = true;
                other.gameObject.GetComponent<PlayerMovement>().caughtInLight = false;
            }
        }
    }
}
