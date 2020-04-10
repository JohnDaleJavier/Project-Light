using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownAudio : MonoBehaviour
{
    AudioSource audi;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        audi.PlayDelayed(1.5f);
    }

}
