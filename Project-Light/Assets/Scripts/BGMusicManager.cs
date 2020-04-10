using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusicManager : MonoBehaviour
{
    public SystemPref systemPref;
    AudioSource audio;
    public AudioClip GameMusic;
    void Start(){
        
        audio = GetComponent<AudioSource>();
        if(systemPref.introShouldPlay = true){
            audio.PlayDelayed(2f);
        }
        else{
            audio.Play();
        }
        
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        audio.volume = systemPref.masterVol;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Instructions"){
            Destroy(this.gameObject);
        }
    }
}
