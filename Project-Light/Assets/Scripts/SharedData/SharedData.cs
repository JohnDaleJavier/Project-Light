using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "SharedData")]
public class SharedData : ScriptableObject
{
    public int setRounds;
    public float setTime;
    public bool pauseGame;
    public int currentMainPlayer;
    public bool respawnAll;
    public float[] playerScoresHold = {0,0,0,0};
    public void OnEnable()
    {
        respawnAll = false;
        pauseGame = false;
        setRounds = 1;
        setTime = 60;
        currentMainPlayer = 0;
    }

    // Update is called once per frame
    public void Awake()
    {
        
    }
}
