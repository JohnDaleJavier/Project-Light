using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public SharedData sharedData;
    AudioSource audi;
    public AudioClip applauseAudi;
    public GameObject[] displayingChar;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        StartCoroutine(Applause());
        for(int i=0; i<displayingChar.Length;i++){
            displayingChar[i].SetActive(false);
        }        
        CheckWinner();

    }
    IEnumerator Applause(){
        yield return new WaitForSeconds(1.5f);
        audi.PlayOneShot(applauseAudi,1f);
        
    }
    void CheckWinner(){
        float max = sharedData.playerScoresHold[0];
        int winnerNum = 0;
        for (int i = 1; i< sharedData.playerScoresHold.Length; i++){
            if(sharedData.playerScoresHold[i] > max){
                max = sharedData.playerScoresHold[i];
                winnerNum = i;
            }
        }
        print(winnerNum.ToString());
        displayingChar[winnerNum].SetActive(true);
    }
}
