using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
