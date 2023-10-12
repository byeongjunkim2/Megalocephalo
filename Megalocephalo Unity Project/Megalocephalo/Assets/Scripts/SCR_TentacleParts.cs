using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SCR_TentacleParts : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;

    [SerializeField]
    private bool isLast = false;
    bool GetIsLast()
    {
        return isLast;
    }
    void SetIsLast(bool IsLate)
    {
        isLast = IsLate;
    }

    private void OnCollisionEnter(Collision collision)
    {

        // get 1
        GameObject ParentPart = transform.parent.gameObject;
        Rigidbody firstRG = ParentPart.transform.Find("1").GetComponent<Rigidbody>();

        // get vector from 1 to player
        Rigidbody playerRG = ParentPart.GetComponent<SCR_TentacleManager>().GetPlayer();
        Vector3 nor = (firstRG.position - playerRG.position).normalized;
        // pull
        // firstRG.AddForce(nor * 20, ForceMode.Impulse);

        // rope will be deleted in .5 seconds
        ParentPart.transform.GetComponent<SCR_TentacleManager>().GetPlayer().transform.Find("Rope_Fixed").GetComponent<SCR_Tentacle>().SetLifeTime(0.5f, true);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trigger")
        {
            // Find the last part, set it as last
            Rigidbody target = GetComponent<Rigidbody>();
            while (target.GetComponent<FixedJoint>() != null
                && !target.GetComponent<SCR_TentacleParts>().GetIsLast())
            {
                target = target.GetComponent<FixedJoint>().connectedBody.GetComponent<Rigidbody>();
            }
            if (target.GetComponent<SCR_TentacleParts>().GetIsLast())
            {
                return;
            }

            Debug.Log(target.gameObject.name + " " + other.gameObject.name);
            // attach it
            target.GetComponent<SCR_TentacleParts>().SetIsLast(true);
            target.gameObject.AddComponent<FixedJoint>();
            target.GetComponent<FixedJoint>().connectedBody = other.transform.parent.GetComponent<Rigidbody>();
            // target.position = other.transform.position;

            // find 1, un-freeze it
            GameObject ParentPart = transform.parent.gameObject;
            Rigidbody firstRG = ParentPart.transform.Find("1").GetComponent<Rigidbody>();
            firstRG.constraints = RigidbodyConstraints.None;

            // add joint to player (pancake)
            Rigidbody playerRB = transform.parent.GetComponent<SCR_TentacleManager>().GetPlayer();
            FixedJoint charaJoint = playerRB.gameObject.AddComponent<FixedJoint>();
            charaJoint.connectedBody = firstRG;

            // stop rope deleting
            ParentPart.transform.GetComponent<SCR_TentacleManager>().GetPlayer().transform.Find("Rope_Fixed").GetComponent<SCR_Tentacle>().SetRopeTimeFlow(false);

            // set vector to zero
            int childrenCount = ParentPart.transform.childCount;
            for (int i = 0; i < childrenCount; i++)
            {
                Transform child = ParentPart.transform.GetChild(i);
                Rigidbody rb = child.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
        }
    }

}
