using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public bool inCamera;
    private float shoottimer = 1.3f;
    public bool CanShoot;
    //Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    UnityEngine.Camera cam;
    Color originColor;
    public GameObject bullet;
    public GameObject Player;

    private void Awake()
    {
      //  rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
        cam = UnityEngine.Camera.main;
        originColor =mat.color;
        Player = FindObjectOfType<SCR_playerMovement>().gameObject;

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
    }
    private void Shoot()
    {
        GameObject instantBullet = Instantiate(bullet, transform.position + (transform.forward*3), transform.rotation);
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
