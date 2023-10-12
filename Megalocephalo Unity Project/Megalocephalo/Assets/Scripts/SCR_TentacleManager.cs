using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_TentacleManager : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRB;

    public Rigidbody GetPlayer()
    {
        return playerRB;
    }

    void Start()
    {

    }

    void Update()
    {
        if (transform.childCount != 0)
        {
            transform.Find("1").position = GetPlayer().position;
        }
    }
}
