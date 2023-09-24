using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targetPos =  target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);
        //transform.position = target.position + offset;




    }
}
