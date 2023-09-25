using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool isActive = false;


    //temp varialbes
    public scr_cameraFollow cam;
    public Transform fixPosition;
    public Transform playerPostion;
    public void ActivateTrigger()
    { 
        if(!isActive)
        {
            //   cam = GetComponent<Camera>();
            cam.target = fixPosition;
            isActive = true;
            Debug.Log("trigger on");
        }
        else
        {
            cam.target = playerPostion;
            isActive = false;
            Debug.Log("trigger off");
        }

    }

}
