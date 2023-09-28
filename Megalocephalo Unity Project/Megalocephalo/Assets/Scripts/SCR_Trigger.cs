using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    bool isActive = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Character")
        {
            ActivateTrigger();

        }
    }


    //temp varialbes
    //public scr_cameraFollow cam;
    public GameObject followCam;
    public Transform fixPosition;
    public Transform playerPostion;

    private void ActivateTrigger()
    { 
        if(!isActive)
        {
            //   cam = GetComponent<Camera>();
            //cam.target = fixPosition;
            //  followCam.GetComponent<Cinemachine>();
            CinemachineVirtualCamera virtualCamera = followCam.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.Follow = fixPosition;
             isActive = true;
            Debug.Log("trigger on");
        }
        else
        {
            // cam.target = playerPostion;
            CinemachineVirtualCamera virtualCamera = followCam.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.Follow = playerPostion;
            isActive = false;
            Debug.Log("trigger off");
        }

    }

}
