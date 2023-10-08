using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetSolver : MonoBehaviour
{
    public int index = 0;
    public int footCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Increment()
    {
        index++;
        index = index % footCount;
    }
}
