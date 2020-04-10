using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStop : MonoBehaviour
{
    public SystemPref systemPref;
    void Start()
    {
        if(systemPref.introShouldPlay == false){
            this.gameObject.SetActive(false);
        }
    }
}
