using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneManager : MonoBehaviour
{
    public Canvas deadSceneCanvasUI;
    public GameObject character;
    private bool isFallen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(character.gameObject.transform.position.y < -50)
        {
            deadSceneCanvasUI.gameObject.SetActive(true);
            if(isFallen == false)
            {
                isFallen = true;
                Debug.Log("Over -50");
            }
        }
    }
}
