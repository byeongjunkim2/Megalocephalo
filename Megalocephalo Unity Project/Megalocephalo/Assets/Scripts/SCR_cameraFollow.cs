using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cameraFollow : MonoBehaviour
{
    public Transform target;
    
    public Vector3 offset;

    float smoothTime = 0.3f;
    Vector3 smoothVelocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
      //  Quaternion rotX = Quaternion.Euler(new Vector3(45, 0, 0));
       // transform.rotation = target.rotation +  ;


        Vector3 targetPos =  target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);
        //transform.position = target.position + offset;

        transform.LookAt(target);
    }
}
