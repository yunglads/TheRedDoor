using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float immuneTimer;

    public bool playerImmune = false;

    HitDetection detect;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;

        detect = GameObject.FindObjectOfType<HitDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //player dead
        }

        immuneTimer += Time.deltaTime;

        if (detect.playerHit)
        {
            immuneTimer = 0f;
            playerImmune = true;
            print("player immune");
        }

        if (immuneTimer >= 2f)
        {
            playerImmune = false;
            immuneTimer = 0f;
        }
    }
}
