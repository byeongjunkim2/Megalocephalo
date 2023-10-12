using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tentacle : MonoBehaviour
{
    [SerializeField]
    private GameObject ropePrefab, parentObj;

    [SerializeField]
    [Range(1, 1000)]
    int length = 3;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool snapFirst = true, snapLast = false;

    [SerializeField]
    Vector3 power = new Vector3(1000, 200, 0);

    [SerializeField]
    Vector3 offset = new Vector3(70, 20, 0);


    private bool isRopeTimeFlow = true;
    private float lifeTime = 0;

    bool isSpawned = false;

    public void SetLifeTime(float newtime, bool shouldFitMin = false)
    {
        if (shouldFitMin)
        {
            lifeTime = Mathf.Min(lifeTime, newtime);
            return;
        }
        lifeTime = newtime;
    }

    public void SetRopeTimeFlow(bool change = true)
    {
        isRopeTimeFlow = change;
    }


    void Start()
    {

    }

    void Update()
    {
        if (isRopeTimeFlow == true)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                ResetFunc();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (isSpawned == false)
            {
                isSpawned = true;
                lifeTime = 1.3f;
                isRopeTimeFlow = true;
                Spawn();
            }
            else
            {
                ResetFunc();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetFunc();
        }

    }

    public void ResetFunc()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ropePart"))
        {
            Destroy(obj);
        }
        isSpawned = false;
    }

    private void Spawn()
    {
        int count = (int)(length / partDistance);

        GameObject obj0;
        obj0 = Instantiate(ropePrefab, new Vector3(transform.position.x, transform.position.y
            + partDistance, transform.position.z), Quaternion.identity, parentObj.transform);


        obj0.transform.eulerAngles = new Vector3(180, 0, 0);
        obj0.name = parentObj.transform.childCount.ToString();
        obj0.GetComponent<Rigidbody>().AddForce(power + (offset * (0 - count)));

        if (snapFirst)
        {
            obj0.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

        for (int i = 1; i < count; i++)
        {
            GameObject obj;
            obj = Instantiate(ropePrefab, new Vector3(transform.position.x, transform.position.y
                + partDistance * (i + 1), transform.position.z), Quaternion.identity, parentObj.transform);
            //obj = Instantiate(ropePrefab, new Vector3(transform.position.x, transform.position.y
            //    - partDistance * (i + 1), transform.position.z), Quaternion.identity, parentObj.transform);

            obj.transform.eulerAngles = new Vector3(180, 0, 0);

            obj.name = parentObj.transform.childCount.ToString();

            obj.GetComponent<Rigidbody>().AddForce(power + (offset * (i - count)));



            parentObj.transform.Find((parentObj.transform.childCount - 1).ToString()).
                GetComponent<Rigidbody>().GetComponent<FixedJoint>().connectedBody =
                parentObj.transform.Find((parentObj.transform.childCount).ToString()).GetComponent<Rigidbody>();
            if (i == count - 1)
            {
                Destroy(obj.GetComponent<FixedJoint>());
            }
        }

    }

}
