using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public bool playerHit = false;

    PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !health.playerImmune)
        {
            health.health -= 50f;
            playerHit = true;
            print("player hurt");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && health.playerImmune)
        {
            playerHit = false;
        }
    }
}
