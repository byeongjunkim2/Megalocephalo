using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage;
    public GameObject host;

    public enum BulletType { Bullet,}    
    public BulletType type;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //other.gameObject.GetComponent<HealthPoint>().IsDead();
        }

        switch (host.tag)
        {
            case "Enemy":



                break;
            case "Player":


                break;
            default: 
                break;
        }




    }



}
