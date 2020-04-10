using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusicManager : MonoBehaviour
{
    public SystemPref systemPref;
    AudioSource audi;
    public AudioClip GameMusic;
    void Start(){
        
        audi = GetComponent<AudioSource>();
        if(systemPref.introShouldPlay == true){
            audi.PlayDelayed(2f);
        }
        else{
            audi.Play();
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
        audi.volume = systemPref.masterVol;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "GameScene"){
            Destroy(this.gameObject);
        }
    }
}
