using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemPref", menuName = "Project-Light/SystemPref", order = 0)]
public class SystemPref : ScriptableObject {
    public float masterVol;
    public bool introShouldPlay;
    void OnEnable(){
        masterVol = 1;
        introShouldPlay = true;
    }
}
