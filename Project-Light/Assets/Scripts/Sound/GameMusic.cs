using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public SystemPref systemPref;
    AudioSource audi;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        audi.volume = systemPref.masterVol;
    }

}
