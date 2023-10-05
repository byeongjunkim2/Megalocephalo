using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

using HPType = System.Int32;

public class HealthPoint : MonoBehaviour
{
    public HPType maxHP = 10; // should be public?
    public HPType currentHP = 10;

    double maxInvulnerableTimeWhenDamaged = 0.15; // should be public?
    double currInvulnerableTime;

    double deltaTimeMultiplier = 1.0;

    bool isInvulnerable = false;

  //  Material mat;
    //Color originColor;
    private void Awake()
    {
        //mat = GetComponent<MeshRenderer>().material;
        //originColor = mat.color;
    }


    // returns Current HP with
    public HPType GetCurrHP()
    {
        return currentHP;
    }

    // Set Current HP
    public void SetCurrHP(HPType value)
    {
        currentHP = value;
        FixHP();
    }

    // returns Current Invulnerable Time
    public double GetCurrInvulnerableTime()
    {
        return currInvulnerableTime;
    }

    // Set Current Invulnerable Time
    public void SetCurrInvulnerableTime(double time)
    {
        currInvulnerableTime= time;
    }

    // returns if invulnerable
    public bool IsInvulnerable()
    {
        return currInvulnerableTime > 0;
    }

    // returns if dead 
    public bool IsDead()
    {
        return currentHP <= 0;
    }

    // Revive this object
    public void Revive(double ratioHP = 1.0)
    {
        //currentHP = maxHP * ratioHP;
        currentHP = (int)(maxHP * ratioHP);
        FixHP();
    }

    // hit this object. this also occur invulnerable time and actual damage
    public void GiveDamage(int damage)
    {
        //currInvulnerableTime = Math.Max(currInvulnerableTime, maxInvulnerableTimeWhenDamaged);
    
        if(!isInvulnerable)
        {
            StartCoroutine(OnDamage(damage));
           // GiveDamage(damage);
        }
    
    }



    // give specific damage to the object. This is NOT occur any invulnerable time (does not make it invulnerable)
    public void GiveInstantDamage (int damage)
    {
        currentHP -= damage;
        FixHP();
    }





    // Make HP to MaxHP if current HP is bigger than MaxHP 
    private void FixHP()
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }


    //void Update()
    //{
    //    double applyingTime  = Time.deltaTime * deltaTimeMultiplier;

    //    currInvulnerableTime -= applyingTime;
    //}


    IEnumerator OnDamage(int damage)
    {
        currentHP -= damage;
        isInvulnerable = true;
    //    mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (currentHP > 0)
        {
      //      mat.color = originColor;
        }
        else
        {
            //mat.color = Color.gray;
            //Destroy(gameObject, 4);
            Destroy(gameObject);
        }

        isInvulnerable = false;
    }

}
