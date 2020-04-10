using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public SharedData sharedData;
    public StartGameManager gameManager;
    public TextMeshProUGUI[] playerScoresUI;
    public TextMeshProUGUI timerUI;
    public Image timerBarUI;

    public float pointsPerTag = 20;
    public float pointsPerCoin = 15;
    float[] playerScores = { 0, 0, 0, 0 };

    float timeLeft;
    float timeLeftHold;
    void Start()
    {
        timeLeft = sharedData.setTime;
        timeLeftHold = sharedData.setTime;
    }
    void Update()
    {
        
        for(int i = 0; i < playerScores.Length; i++)
        {
            if(playerScores[i] < 0)
            {
                playerScores[i] = 0; 
            }
            playerScoresUI[i].text = playerScores[i].ToString("F0") ;
        }
        if(!sharedData.pauseGame)
        {
            playerScores[sharedData.currentMainPlayer] += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            timerUI.text = ("Time Left: " + timeLeft.ToString("F0"));
            timerBarUI.fillAmount = timeLeft / timeLeftHold;

        }
        if(timeLeft < 0)
        {
            StartCoroutine(EndRound());
        }
    }
    public void AddScoreTag(int playerID)
    {
        playerScores[playerID] += pointsPerTag;
    }
        public void AddScoreCoin(int playerID)
    {
        playerScores[playerID] += pointsPerCoin;
    }
    public void SubtractScoreTag(int playerID)
    {
        playerScores[playerID] -= pointsPerTag;
    }
    public IEnumerator EndRound(){
        for(int i = 0; i < playerScores.Length; i++)
        {
            sharedData.playerScoresHold[i] = playerScores[i];
            print(sharedData.playerScoresHold[i].ToString());
        }
        sharedData.pauseGame = true;
        gameManager.EndGameUI();
        yield return new WaitForSeconds(5);
        sharedData.pauseGame = false;
        SceneManager.LoadScene("EndGame");
    }
}
