using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

/* This is a class to handle large-scale audio tasks such as level music and ambience changes that aren't tied to a single specific game object.
 * It will handle the interface betwen Wwise states and RTPCs and Unity scripting.
 */

public class AudioController : MonoBehaviour
{
    // Variables for various control functions
    private bool musicPlaying;

    // Start is called before the first frame update
    void Start()
    {
        if (musicPlaying == false)
        {
            AkSoundEngine.PostEvent("TestMusic", gameObject);
            musicPlaying = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
