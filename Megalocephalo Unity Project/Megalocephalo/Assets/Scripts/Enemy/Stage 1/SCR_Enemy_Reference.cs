using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : MonoBehaviour
{
    // hp related
    public int maxHealth;
    public int health;


    Material mat;
    Color originColor;
    HealthPoint hp;

    private void Awake()
    {
        hp = GetComponent<HealthPoint>();
        mat = GetComponent<MeshRenderer>().material;
        originColor = mat.color;

        hp.maxHP = maxHealth;
        hp.currentHP = health;
    }

    private void Update()
    {
     
        if (hp.IsInvulnerable())    //make box red when it get damaged
        {
            mat.color = Color.red;
        }
        else
        {
            mat.color = originColor;
        }

    }
 
   
}
