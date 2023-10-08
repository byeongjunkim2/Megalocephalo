using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // hp related
    public int maxHealth;
     public int health;

    // camera related
    public bool inCamera;
    UnityEngine.Camera cam;

    // behavior related 
    private float shoottimer = 1.3f;
    public bool CanShoot;

    //Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    Color originColor;
    public GameObject bullet;
    public GameObject Player;
    HealthPoint hp;

    private void Awake()
    {
        hp = GetComponent<HealthPoint>();
        //  rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
        cam = UnityEngine.Camera.main;
        originColor = mat.color;
        Player = FindObjectOfType<SCR_playerMovement>().gameObject;

    }

    private void Update()
    {
       
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            inCamera = true ;
            shoottimer -= Time.deltaTime;
        }
        else { inCamera = false; shoottimer = 1.3f; }

        if (inCamera&& shoottimer<0.0f && CanShoot)
        {
            Rotate();
            Shoot();
            shoottimer = 1.3f;
        }

        if (hp.IsInvulnerable())    //make box red when it get damaged
        {
            mat.color = Color.red;
        }
        else
        {
            mat.color = originColor;
        }

    }
    private void Shoot()
    {
        GameObject instantBullet = Instantiate(bullet, transform.position + (transform.forward*3), transform.rotation);
        instantBullet.GetComponent<Bullet>().SetBullet(this.gameObject, Bullet.BulletType.bullet);
        Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * 50;
    }
    private void Rotate()
    {
        Vector3 PlayerTrans = Player.transform.position;
        if (cam.transform.rotation.y > Quaternion.Euler(0, -0.40f, 0).y) {
            //Debug.Log(cam.transform.rotation);
            if (PlayerTrans.x - transform.position.x > 0.0)
            {
                transform.rotation = Quaternion.Euler(0, -270.0f, 0);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -90.0f, 0);
            }
        }
        else
        {
            //Debug.Log("CAM IS X!\n");
            if (PlayerTrans.z - transform.position.z > 0.0)
            {
                transform.rotation = Quaternion.Euler(0, -0.0f, 0);

            }
            else
            {
                transform.rotation = Quaternion.Euler(0, -180.0f, 0);
            }
        }
        
    }
   
}
