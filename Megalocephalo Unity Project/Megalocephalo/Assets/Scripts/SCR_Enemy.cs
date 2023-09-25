using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int health;

    //Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    Color originColor;

    private void Awake()
    {
      //  rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;

        originColor=mat.color;
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            health -= bullet.damage;
            StartCoroutine(OnDamage());
            Debug.Log("Current Enemy HP : " + health);
        }
    }



    IEnumerator OnDamage()
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (health > 0)
        {
            mat.color = originColor;
        }
        else
        {
            //mat.color = Color.gray;
            //Destroy(gameObject, 4);
            Destroy(gameObject);
        }

    }
}
