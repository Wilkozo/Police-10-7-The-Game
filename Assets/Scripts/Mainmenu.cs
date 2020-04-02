using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    private int NextSceneToLoad;

    public void PlayGame()
    {
        //FindObjectOfType<AudioManager>().Play("Button");
        // Gets The Next Scene for the Play Mode
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        //Application.LoadLevel(0);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}