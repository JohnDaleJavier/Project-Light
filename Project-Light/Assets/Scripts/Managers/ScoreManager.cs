using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public SharedData sharedData;
    public TextMeshProUGUI[] playerScoresUI;
    public TextMeshProUGUI timerUI;
    public Image timerBarUI;

    public float pointsPerTag = 20;
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
        playerScores[sharedData.currentMainPlayer] += Time.deltaTime;
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
            timeLeft -= Time.deltaTime;
            timerUI.text = ("Time Left: " + timeLeft.ToString("F0"));
            timerBarUI.fillAmount = timeLeft / timeLeftHold;

        }

    }
    public void AddScoreTag(int playerID)
    {
        playerScores[playerID] += pointsPerTag;
        print(playerScores[playerID].ToString());
    }
    public void SubtractScoreTag(int playerID)
    {
        playerScores[playerID] -= pointsPerTag;
        print(playerScores[playerID].ToString());
    }
}
