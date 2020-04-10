using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public SystemPref systemPref;
    public string[] scene;
    int sceneNum;
    public Animator anim;

    public void StartGame()
    {
        sceneNum = 0;
        systemPref.introShouldPlay = true;
        StartCoroutine(Cutscene());

        //SceneManager.LoadScene(scene[0].ToString());

    }
    public void Options()
    {
        sceneNum = 1;
        StartCoroutine(Cutscene());
        //SceneManager.LoadScene(scene[1].ToString());
        systemPref.introShouldPlay = false;
    }
    public void Credits()
    {
        sceneNum = 2;
        StartCoroutine(Cutscene());
        //SceneManager.LoadScene(scene[2].ToString());
        systemPref.introShouldPlay = false;
    }
    public void Instructions()
    {
        sceneNum = 3;
        StartCoroutine(Cutscene());
        systemPref.introShouldPlay = false;
    }
    public void QuitGame()
    {
        StartCoroutine(Cutscene());
        Application.Quit();
    }
    public void ReturnToMenu(){
        sceneNum = 4;
        StartCoroutine(Cutscene());
    }
    IEnumerator Cutscene(){
        anim.SetBool("ChangingScene",true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("ChangingScene",false);
        SceneManager.LoadScene(scene[sceneNum].ToString());

    }
}
