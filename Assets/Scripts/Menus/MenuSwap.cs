using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MenuSwap : MonoBehaviour
{

    public string levelToLoad;
    public Image title;
    public Image controls;
    public Text titleText;


    private void Start()
    {
        controls.enabled = false;
    }

    public void PlayGame() {
        Application.LoadLevel("levelToLoad");
    }
    
    public void controlsClicke()
    {
        titleText.enabled = false;
        controls.enabled = true;
        title.enabled = false;
    }

    public void onQuitClicked() {
        Application.Quit();
    }


}
