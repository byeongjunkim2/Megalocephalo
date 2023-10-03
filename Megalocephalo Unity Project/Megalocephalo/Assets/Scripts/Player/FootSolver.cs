using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class FootSolver : MonoBehaviour
{
    public float footSpacing = 1.0f;
    public float peddle = 4.0f;
    public float footHeight = 0.2f;
    public float stepHeight = 1.0f;
    public float stepDistance = 0.1f;
    public float speed = 1.0f;
    
    
    public FeetSolver solver;
    public int legNum = 0;
    

    public Transform body;
    public StarterAssetsInputs controller;

    private Vector3 newPosition, oldPosition, currentPosition;
    private float lerp = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
        oldPosition = newPosition;
        currentPosition = oldPosition;

        Ray ray = new Ray(body.position + (body.right * footSpacing) + Vector3.right*controller.move.x*peddle , Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit info, 10, 1))
        {
            lerp = 0;
            newPosition = info.point + (Vector3.up * footHeight);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = currentPosition;

        Ray ray = new Ray(body.position + (body.right * footSpacing) + Vector3.right*controller.move.x*peddle , Vector3.down);
        if (solver.index == legNum && Physics.Raycast(ray, out RaycastHit info, 10, 1))
        {
            if (Vector3.Distance(newPosition, info.point + (Vector3.up * footHeight)) > stepDistance)
            {
                lerp = 0;
                newPosition = info.point + (Vector3.up * footHeight);
            }
        }
        if (lerp < 1)
        {
            Vector3 footPosition = Vector3.Lerp(oldPosition, newPosition, lerp);
            footPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPosition = footPosition;
            lerp += Time.deltaTime * speed;

            if (lerp >= 1)
                solver.Increment();
        }
        else
            oldPosition = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentPosition, 0.5f);
    }
}