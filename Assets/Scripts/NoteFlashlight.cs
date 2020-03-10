using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFlashlight : MonoBehaviour
{
    public Light flashlight;
    public float noteLightIntensity;
    float originalIntensity = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            flashlight.intensity = noteLightIntensity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            flashlight.intensity = originalIntensity;
        }
    }
}
