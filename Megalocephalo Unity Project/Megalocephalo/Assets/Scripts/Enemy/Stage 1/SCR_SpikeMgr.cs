using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpikeMgr : MonoBehaviour
{
    private bool fired = false;
    public GameObject player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Base Layer.Idle", 0, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.GetComponent<Transform>().position; 
        Vector3 my_position = GetComponent<Transform>().position; 

        if (!fired && 16.0 > Vector3.Distance(position, my_position))
        {
            animator.Play("Base Layer.Sneeze", 0, 0.0f);
            foreach (Transform child in transform)
            {
                SCR_Spike spike = child.GetComponent<SCR_Spike>();
                spike.SetFire();
            }
            fired = true;
        }
    }
}
