using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject deadMenuCanvas;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        deadMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void displayDeadUI() 
    {
        GameIsPaused = true;
        Time.timeScale = 1.0f;
        deadMenuCanvas.SetActive(true);
    }

    public void ToSettingMenu()
    {
        
    }

    public void OnCliCKToMainMenu()
    {
        AkSoundEngine.PostEvent("StopAll", gameObject); // Stop all audio upon returning to Main Menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("SCENE_MainMenu");
    }

    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Exit Button Clicked");
    }

    public void OnClickGoBackToGameScreen()
    {
        Resume();
        Debug.Log("Go Back To Play Game");
    }

}