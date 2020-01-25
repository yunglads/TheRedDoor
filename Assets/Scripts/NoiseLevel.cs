using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NoiseLevel : MonoBehaviour
{
    public float noiseLevel = 0;

    RigidbodyFirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.movementSettings.CurrentTargetSpeed == 0f)
        {
            noiseLevel = 0f;
            //print("Not moving");
        }

        if (controller.movementSettings.CurrentTargetSpeed == controller.movementSettings.StrafeSpeed || controller.movementSettings.CurrentTargetSpeed == controller.movementSettings.ForwardSpeed)
        {
            noiseLevel = 5f;
        }

        if (controller.movementSettings.CurrentTargetSpeed == controller.movementSettings.ForwardSpeed * controller.movementSettings.RunMultiplier)
        {
            noiseLevel = 10f;
        }
    }
}
