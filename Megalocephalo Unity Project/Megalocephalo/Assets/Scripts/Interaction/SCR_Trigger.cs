using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TriggerType { CamRotation, ChangeTarget };
    public TriggerType type;

    bool isActive = false;

    //temp varialbes
    public GameObject followCam;
    public Transform fixPosition;
    public Transform playerPostion;
    public GameObject player;
    //```````````````````````````````````
    public float rotationSpeed = 1f;
    public float targetRotationY = 0f;
    //private bool isRotating = false;

    private void Awake()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Character")
        {
            ActivateTrigger();

        }
    }




    private void ActivateTrigger()
    {
        switch (type)
        {
            case TriggerType.CamRotation:
                //player.GetComponent<ThirdPersonController>().AdjustPosition(transform.position);
                player.transform.position = new Vector3( transform.position.x, player.transform.position.y, transform.position.z) ;
     
                RotateCamera();
                //Vector3 newPos = transform.position;
                //player.transform.position.x = transform.position.x;

                break;
            case TriggerType.ChangeTarget:
                ChangeFollowObject();
                break;
        }

    }



    void ChangeFollowObject()
    {
        if (!isActive)
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

    void RotateCamera()
    {
        if (!isActive)
        {

            //followcam targetangle += rotate degree
            //followcma isrotating = true;
            followCam.GetComponent<CamRotate>().StartRotate(targetRotationY);
            //playerPostion.transform.position.x =  transform.position.x;

            isActive = true;
            //  StartCoroutine("TriggerDelay");
        }
        else
        {
            followCam.GetComponent<CamRotate>().StartRotate(-targetRotationY);

            isActive = false;
        }
    }

    //private IEnumerator TriggerDelay()
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    isActive = false;
    //    yield break;
    //}

}
