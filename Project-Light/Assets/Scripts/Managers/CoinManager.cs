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
                print(coins.Length.ToString()+"ah");
        RandCoin(0);

    }
    void Update()
    {
        
    }
    public void RandCoin(int CoinID){
        int randomNum = Random.Range(0, coins.Length);
        if(randomNum == CoinID){
            randomNum--;
            if(randomNum<0){
                randomNum = coins.Length -1;
            }
        }
        print(randomNum.ToString());
        coins[randomNum].SetActive(true);
    }
}
