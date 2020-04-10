using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public SharedData sharedData;
    public ScoreManager scoreManager;
    public CoinManager coinManager;
    public AudioSource audi;
    public AudioClip coinAudi;
    public int coinID;
    void Start()
    {
        //audi = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<PlayerMovement>() as PlayerMovement)
        {
            if (other.gameObject.GetComponent<PlayerMovement>().playerId == sharedData.currentMainPlayer)
            {
                audi.PlayOneShot(coinAudi,1f);
                scoreManager.AddScoreCoin(sharedData.currentMainPlayer);
                coinManager.RandCoin(coinID);
                this.gameObject.SetActive(false);
            }
        }
    }
}
