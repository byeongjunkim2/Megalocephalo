using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SCR_Floor : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    public Vector3 offsetPos;
    public float floorMovementSpeed = 12;

    bool goingEndPos = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        endPos = startPos + offsetPos;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.position);

        float ElapsedTime = Time.deltaTime;
        Vector3 vec;

        if (goingEndPos)
        {
            vec = (endPos - startPos).normalized;
            gameObject.transform.Translate(vec * floorMovementSpeed * Time.deltaTime);

            if (Vector3.Distance(gameObject.transform.position, endPos) <= floorMovementSpeed * ElapsedTime)
            {
                gameObject.transform.position = endPos;
                goingEndPos = !goingEndPos;
            }
        }
        else
        {
            vec = (startPos - endPos).normalized;
            gameObject.transform.Translate(vec * floorMovementSpeed * ElapsedTime);

            if (Vector3.Distance(gameObject.transform.position, startPos) <= floorMovementSpeed * ElapsedTime)
            {
                gameObject.transform.position = startPos;
                goingEndPos = !goingEndPos;
            }
        }

    }
}
