using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // �ٸ� ��ũ��Ʈ���� ���� ������ �����ϵ��� static
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
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

    public void ToSettingMenu()
    {
        Debug.Log("����E�̱����Դϴ�...");
    }

    public void OnCliCKToMainMenu()
    {
        AkSoundEngine.PostEvent("StopAll", gameObject); // Stop all audio upon returning to Main Menu
        Debug.Log("����E�̱����Դϴ�...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
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