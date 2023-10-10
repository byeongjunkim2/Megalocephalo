using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HealthChunk : MonoBehaviour
{
    public int chunkIndex = 0;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<HealthPoint>().GetCurrHP() >= chunkIndex)
        {
            //filled
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            //hollow
            GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.25f, 0.25f, 1);
        }
    }
}
