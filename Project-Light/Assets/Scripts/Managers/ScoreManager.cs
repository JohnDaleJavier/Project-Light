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
    public Image raceDistanceUI;

    public int pointsPerTag = 20;
    int[] playerScores = { 0, 0, 0, 0 };

    float timeLeft;
    void Start()
    {
        timeLeft = sharedData.setTime;
    }
    void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            playerScoresUI[i].text = playerScores[i].ToString() ;
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
