using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HPType = System.Int32;

public class HealthPoint : MonoBehaviour
{
    HPType maxHP = 10; // should be public?
    HPType currentHP;

    double maxInvulnerableTimeWhenDamaged = 0.15; // should be public?
    double currInvulnerableTime;

    double deltaTimeMultiplier = 1.0;

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
    public void HitObject(int damage)
    {
        currInvulnerableTime = Math.Max(currInvulnerableTime, maxInvulnerableTimeWhenDamaged);
        GiveDamage(damage);
    }

    // give specific damage to the object. This is NOT occur any invulnerable time (does not make it invulnerable)
    public void GiveDamage (int damage)
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

    void Start()
    {
    }

    void Update()
    {
        double applyingTime  = Time.deltaTime * deltaTimeMultiplier;

        currInvulnerableTime -= applyingTime;
    }
}
