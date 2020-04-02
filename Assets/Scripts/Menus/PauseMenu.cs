using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GameObject.Find("PauseMenu");
        pauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            Application.LoadLevel("Mainmenu");
        }
    }
}
