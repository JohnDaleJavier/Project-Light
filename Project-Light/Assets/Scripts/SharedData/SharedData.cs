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
    public void OnEnable()
    {
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
