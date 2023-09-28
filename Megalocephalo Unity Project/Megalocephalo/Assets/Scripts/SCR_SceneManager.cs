using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneManager : MonoBehaviour
{

    public GameObject character;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(character.gameObject.transform.position.y < -50)
        {
            SceneManager.LoadScene("DeadScene");
        }
    }
}
