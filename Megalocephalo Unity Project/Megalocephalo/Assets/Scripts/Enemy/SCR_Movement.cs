using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AK.Wwise;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Image;

public class Movement : MonoBehaviour
{
    //private float moveSpeed = 5.0f;
    //private float jumpForce = 3.0f;
    //private float gravity = -9.81f;
    public float moveSpeed = 5.0f;
    public float jumpForce = 3.0f;
   // public float maxJumpForce = 5.0f;
    public float gravity = -9.81f;
    public float slideForce = 5f;

    private Vector3 moveDirection;

    private CharacterController characterController;
    private Renderer characterRenderer;

    bool isJumping;
    bool InJump;
    float Coyotetimer =0.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        characterRenderer = GetComponent<Renderer>();
    }
    //Changes 9/26/2023: Jump is depends on Coyote timer and INjump, Jump functions makes Injump=true,
    //Coyote timer ticks down to 0 when falling, if 0, Injump =false; coyote time resets only when the character is 'grounded'
    // Update is called once per frame
    void Update()
    {
        
        if (characterController.isGrounded == false)
        {
            Coyotetimer -= Time.deltaTime;
            if (Coyotetimer < 0.0f) 
            { 
                InJump = false;
            }
            moveDirection.y += gravity * Time.deltaTime;// * 20;
        }
        else if (characterController.isGrounded == true)
        {
            Coyotetimer = 0.15f;
        }

      

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        //Debug.Log(moveDirection);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // when character reaches his head on ceiling, it will falling immediately
        if (InJump == true)
        {
            if (Physics.BoxCast(transform.position, characterRenderer.bounds.size * 0.5f, Vector3.up, out RaycastHit hitInfo, Quaternion.identity, 1.05f))
            {
                moveDirection.y = 0;
                Coyotetimer = 0;
            }
        }

        // when character collides with floor with falling, it's falling speed will be 0
        if (moveDirection.y < -0.1)
        {
            if (Physics.BoxCast(transform.position, characterRenderer.bounds.size * 0.5f, Vector3.down, out RaycastHit hitInfo, Quaternion.identity,  1.05f))
            {
                moveDirection.y = 0;
                InJump = false;
            }
        }
    }

    public void MoveTo(Vector3 direction)
    {
        //    moveDirection = direction;

        moveDirection = new Vector3(direction.x, moveDirection.y,direction.z);

    }
    public void MoveForward(float movement)
    {

        moveDirection = new Vector3(0, moveDirection.y, 0) + gameObject.transform.forward * Math.Abs(movement);

    }
    public void JumpTo()
    {
        if(Coyotetimer> 0.0f && !InJump)
        {
            InJump = true;
            moveDirection.y = jumpForce;
            AkSoundEngine.PostEvent("TestSFX", gameObject);  // Play jump sfx here
           
        }
    }
    public void JumpStop()
    {
        if (characterController.isGrounded == false /*&& isJumping*/ && moveDirection.y > 0)
        {
            moveDirection.y = 0;
          
        }
    }

    private void OnDrawGizmos()
    {
        //Handles.Label(transform.position, "JUMP: " + InJump);
    }

}
