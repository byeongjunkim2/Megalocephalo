using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage;
    public GameObject shooter;
     TrailRenderer trailRenderer;
    public enum BulletType { bullet,}    
    public BulletType type;

    public void SetBullet(GameObject shooterObj, BulletType bulletType)
    {
        shooter = shooterObj;
        type = bulletType;
        //damage =   ;

        trailRenderer = GetComponent<TrailRenderer>();
        Gradient gradient = new Gradient();
        switch (shooter.tag)
        {
            case "Enemy":
                GradientColorKey[] colorKeys = new GradientColorKey[3];
                colorKeys[0] = new GradientColorKey(Color.red, 0.0f);    // start point color
                colorKeys[1] = new GradientColorKey(Color.yellow, 0.5f);  // mid point color
                colorKeys[2] = new GradientColorKey(Color.white, 1.0f);  //end

                GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
                alphaKeys[0] = new GradientAlphaKey(1.0f, 0.0f); // alpha 1
                alphaKeys[1] = new GradientAlphaKey(0.0f, 1.0f); // alpha 0
                gradient.SetKeys(colorKeys, alphaKeys);
                trailRenderer.colorGradient = gradient;
                break;
            case "Player":
              


                break;
            default:
                break;
        }

   
    }
    
    private void OnTriggerEnter(Collider other)
    {
        switch (shooter.tag)
        {
            case "Enemy":
                OnEnemyBulletTriggerEnter(other);


                break;
            case "Player":

                OnPlayerBulletTriggerEnter(other);
                break;
            default: 
                break;
        }
    }


    void OnPlayerBulletTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            //change hp class function. check obj is dead in that class.
            other.GetComponent<HealthPoint>().GiveDamage(damage);
            Destroy(gameObject);
        }
    }

    void OnEnemyBulletTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            //change hp class function. check obj is dead in that class.
            other.GetComponent<HealthPoint>().GiveDamage(damage);
            Destroy(gameObject);
        }
    }

}
