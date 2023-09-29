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
        SceneManager.LoadScene("Prototype2_3dAsset");
    }

    public void PlayAudioZoo()
    {
        SceneManager.LoadScene("PrototypeAudioZoo");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
