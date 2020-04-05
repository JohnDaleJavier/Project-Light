using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameManager : MonoBehaviour
{
    public SharedData sharedData;
    public float gameStartWaitTime = 2;
    public Animator menuAnim;

    void Start()
    {
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart() {
        sharedData.pauseGame = true;
        //set to start game wait time
        yield return new WaitForSeconds(gameStartWaitTime);
        sharedData.pauseGame = false;
    }

    public void EndGameUI(){
        menuAnim.SetBool("GameEnd", true);
    }
}
