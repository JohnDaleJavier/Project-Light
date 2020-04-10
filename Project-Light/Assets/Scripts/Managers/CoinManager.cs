using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] coins;
    void Start()
    {
        for(int i = 0; i < coins.Length; i++){
            coins[i].SetActive(false);
        }
        RandCoin(0);
    }
    public void RandCoin(int CoinID){
        int randomNum = Random.Range(0, coins.Length);
        if(randomNum == CoinID){
            randomNum--;
            if(randomNum<0){
                randomNum = coins.Length -1;
            }
        }
        coins[randomNum].SetActive(true);
    }
}
