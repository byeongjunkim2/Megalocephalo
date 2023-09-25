using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SCR_playerMovement : MonoBehaviour
{

    private KeyCode jumpKeyCode = KeyCode.Space;
    private KeyCode attackKeyCode = KeyCode.X;
    private Movement movement;
    private Attack attack;

    public GameObject bullet;

    // Start is called before the first frame update
    private void Awake()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        //Debug.Log(x);

        //movement by character controller
        movement.MoveTo(new Vector3(x, 0, 0));
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement.JumpTo();
        }
        if (Input.GetKeyUp(jumpKeyCode))
        {
            movement.JumpStop();
        }

        transform.LookAt(transform.position + new Vector3(x, 0, 0));

        if (Input.GetKeyDown(attackKeyCode))
        {
            GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation );
            Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = transform.forward * 80;
           // bulletRigid.velocity = transform.right * 80;
            // transform.right
        }

        //movement by transform

        //moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        //transform.position += moveVec * speed * Time.deltaTime;


    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trigger")
        {
            Trigger trigger = other.gameObject.GetComponent<Trigger>();
            trigger.ActivateTrigger();

        }
    }





}
