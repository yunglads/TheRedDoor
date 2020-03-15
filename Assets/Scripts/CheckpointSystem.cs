using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    //public BoxCollider trigger;
    public Transform spawnpoint;
    public Transform playerSpawnpoint;
    bool triggerEntered;
    // Update is called once per frame
    void Update()
    {
        if (triggerEntered)
        {
            playerSpawnpoint.position = spawnpoint.position;
            playerSpawnpoint.rotation = spawnpoint.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerEntered = false;
        }
    }
}
