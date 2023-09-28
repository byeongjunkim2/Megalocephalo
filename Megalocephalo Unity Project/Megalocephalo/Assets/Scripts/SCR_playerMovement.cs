using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using AK.Wwise;

public class SCR_playerMovement : MonoBehaviour
{
    private KeyCode rightMoveKeyCode = KeyCode.RightArrow;
    private KeyCode lefttMoveKeyCode = KeyCode.LeftArrow;

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode attackKeyCode = KeyCode.X;
    private Movement movement;
    private Attack attack;

    // attack stuff
    public GameObject bullet;
    private float chargedTime;
    private float maxChargeTime = 0.7f;

    // particle
    public ParticleSystem chargingParticleSystem;
    // public ParticleSystem[] chargingParticleSystems;

    // rotation stuff
    private float currentRotation;
    private float targetRotation;
    public float angleOffset = 45.0f;
    
    // Start is called before the first frame update
    private void Awake()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();

        targetRotation = angleOffset;
        currentRotation = targetRotation;
       
        chargingParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>(true);
        //chargingParticleSystems = gameObject.GetComponentsInChildren<ParticleSystem>(true);

        chargingParticleSystem.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
     

        float x = 0; //= Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(rightMoveKeyCode))
        {
            x = 1;
            targetRotation = angleOffset * x;
            if (new Vector3(-x, 0, 0) == transform.forward || new Vector3(0, 0, -x) == transform.forward)
            {
                transform.LookAt(transform.position - transform.forward);
            }
        }
        else if (Input.GetKey(lefttMoveKeyCode))
        {
            x = -1;
            targetRotation = angleOffset * x;
            if (new Vector3(-x, 0, 0) == transform.forward || new Vector3(0, 0, -x) == transform.forward)
            {
                transform.LookAt(transform.position - transform.forward);
            }
        }
        else
        {
            x = 0;
        }

        // handle rotation later
        currentRotation = Mathf.LerpAngle(currentRotation, targetRotation, 0.1f);


        //movement by character controller
        // movement.MoveTo(new Vector3(x, 0, 0));
        movement.MoveForward(x);
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement.JumpTo();
        }
        if (Input.GetKeyUp(jumpKeyCode))
        {
            movement.JumpStop();
        }

        // transform.LookAt(transform.position + new Vector3(x, 0, 0));

        if (Input.GetKeyDown(attackKeyCode))
        {
            NormalAttack();
            chargedTime = 0;
        }

        // charge related
        if (Input.GetKey(attackKeyCode))
        {
            chargedTime += Time.deltaTime;
        }
        if(chargedTime > maxChargeTime)
        {
            Debug.Log("Charging!!\n");
            chargingParticleSystem.gameObject.SetActive(true);
            if (Input.GetKeyUp(attackKeyCode))
            {
                ChargeAttack();
                chargedTime = 0;
                chargingParticleSystem.gameObject.SetActive(false);
            }
        }


        //movement by transform

        //moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        //transform.position += moveVec * speed * Time.deltaTime;


    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Trigger")
    //    {
    //        Trigger trigger = other.gameObject.GetComponent<Trigger>();
    //        trigger.ActivateTrigger();

    //    }
    //}

    private void NormalAttack()
    {
        AkSoundEngine.PostEvent("SFX_playerShoot", gameObject); // Play weapon sfx here
        GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * 80;
        // bulletRigid.velocity = transform.right * 80;
        // transform.right
    }

    private void ChargeAttack()
    {
        AkSoundEngine.PostEvent("SFX_playerShoot", gameObject); // for now, 3x sound to represent charging attack
        AkSoundEngine.PostEvent("SFX_playerShoot", gameObject);
        AkSoundEngine.PostEvent("SFX_playerShoot", gameObject);
        for (int i = 0; i < 3; i++)
        {
            Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y + ((i - 1) * 2), transform.position.z);
            GameObject instantBullet = Instantiate(bullet, bulletPos, transform.rotation);
            Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = transform.forward * 80;
        }
    }
}


