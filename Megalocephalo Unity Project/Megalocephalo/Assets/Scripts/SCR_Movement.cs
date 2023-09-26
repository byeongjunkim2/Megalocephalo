using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AK.Wwise;
using System;

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

    bool isJumping;
    bool InJump;
    float Coyotetimer =0.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    //Changes 9/26/2023: Jump is depends on Coyote timer and INjump, Jump functions makes Injump=true,
    //Coyote timer ticks down to 0 when falling, if 0, Injump =false; coyote time resets only when the character is 'grounded'
    // Update is called once per frame
    void Update()
    {
        
        if (characterController.isGrounded == false)
        {
            Coyotetimer -= Time.deltaTime;
            if (Coyotetimer < 0.0f) { InJump = false;  }
            moveDirection.y += gravity * Time.deltaTime;// * 20;
        }
        if(characterController.isGrounded == true )
        {
           
            Coyotetimer = 0.2f;
        }
       
        //if (characterController.isGrounded)
        //{

            //    RaycastHit hit;
            //    if (Physics.Raycast(transform.position, Vector3.down, out hit))
            //    {
            //        float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            //        if (slopeAngle > characterController.slopeLimit)
            //        {
            //            //Debug.DrawRay(transform.position, Vector3.down, Color.green);
            //            //// 경사면과 수평인 방향을 계산
            //            ////Vector3 slideDirection = Vector3.(hit.normal, Vector3.up);
            //            //Vector3 slideDirection = hit.normal + Vector3.up;     
            //            //// slideDirection = new Vector3(slideDirection.x, 0, 0);
            //            //moveDirection += slideDirection * slideForce;

            //            //moveDirection += gravity * Mathf.Cos(slopeAngle);



            //        }
            //    }
            //}


            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

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
            // isJumping = true;
        }
    }
    public void JumpStop()
    {
        if (characterController.isGrounded == false /*&& isJumping*/ && moveDirection.y > 0)
        {
            moveDirection.y = 0;
           // isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, "JUMP: " + InJump);
    }

}
