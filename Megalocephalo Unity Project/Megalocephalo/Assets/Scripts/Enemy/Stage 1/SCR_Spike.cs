using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Spike : Bullet
{
    public Vector3 direction;
    //private bool fire = false;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (fire)
    //    {
    //        Rigidbody rigidBody = GetComponent<Rigidbody>();
    //        rigidBody.AddForce(direction * 20f, ForceMode.Impulse);
    //        fire = false;
    //    }
    //}

    public void SetFire()
    {
        Rigidbody bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = direction * 20f;
        //SetBullet(shooter, BulletType.spike);
        //fire = true;
    }
}
