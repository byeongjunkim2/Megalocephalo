using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    public Button PrototypeB;
    public Button AudioZooB;
    public Button QuitB;
    void Start()
    {
        PrototypeB.onClick.AddListener(PlayDemo);
        AudioZooB.onClick.AddListener(PlayAudioZoo);
        QuitB.onClick.AddListener(Quit);
    }
        public void PlayDemo()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void PlayAudioZoo()
    {
        SceneManager.LoadScene("AudioZoo");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
