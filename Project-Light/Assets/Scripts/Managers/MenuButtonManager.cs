using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public string[] scene;

    public void StartGame()
    {
        
        SceneManager.LoadScene(scene[0].ToString());
    }
    public void Options()
    {
        SceneManager.LoadScene(scene[1].ToString());
    }
    public void Credits()
    {
        SceneManager.LoadScene(scene[2].ToString());
    }
    public void Instructions()
    {
        SceneManager.LoadScene(scene[3].ToString());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu(){
        SceneManager.LoadScene(scene[4].ToString());
    }

}
