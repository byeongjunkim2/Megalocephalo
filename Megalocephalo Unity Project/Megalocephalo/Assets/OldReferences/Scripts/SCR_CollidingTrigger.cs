using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SCR_CollidingTrigger : MonoBehaviour
{
    public Camera mainCamera;
    private bool isCollided = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided!!!!!!!!!!!!\n");
        if (other.gameObject.tag == "Character")
        {
            if (isCollided == false)
            {
                Vector3 nowOffset = mainCamera.GetComponent<scr_cameraFollow>().offset;
                Debug.Log(nowOffset);
                if (nowOffset == new Vector3(0, 9, -40))
                {
                    mainCamera.GetComponent<scr_cameraFollow>().offset = new Vector3(40, 9, 0);
                    // other.gameObject.transform.SetPositionAndRotation(transform.position + new Vector3(100,0,0), other.gameObject.transform.rotation);
                    other.gameObject.transform.LookAt(other.gameObject.transform.position + new Vector3(0, 0, 1));
                }
                else
                {
                    mainCamera.GetComponent<scr_cameraFollow>().offset = new Vector3(0, 9, -40);
                    // other.gameObject.transform.SetPositionAndRotation(transform.position, other.gameObject.transform.rotation);
                    other.gameObject.transform.LookAt(other.gameObject.transform.position + new Vector3(-1, 0, 0));
                }
            }
            isCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            isCollided = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
