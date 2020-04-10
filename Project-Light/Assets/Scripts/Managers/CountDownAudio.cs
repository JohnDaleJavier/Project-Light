using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAudio : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayDelayed(1.5f);
    }

}
