using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCR_DeadScene : MonoBehaviour
{
    public Button MainMenuButton;

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.onClick.AddListener(GoMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
