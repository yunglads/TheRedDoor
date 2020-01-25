using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;

    public bool toggleOn = true;

    // Update is called once per frame
    void Update()
    {
        if (toggleOn && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = false;
            toggleOn = false;
            return;
        }
        else if (!toggleOn && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = true;
            toggleOn = true;
            return;
        }
    }
}
