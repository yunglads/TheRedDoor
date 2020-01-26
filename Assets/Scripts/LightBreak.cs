using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBreak : MonoBehaviour
{
    public Light lightSource;
    public Light flashlight;
    AudioSource source;
    public AudioClip lightBreak;
    public BoxCollider collider1;
    public BoxCollider collider2;

    float waitTime;
    bool startTimer = false;
    bool playClip = false;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playClip)
        {
            source.PlayOneShot(lightBreak);
            playClip = false;
            startTimer = false;
            Destroy(collider1);
            Destroy(collider2);
        }

        if (startTimer)
        {
            waitTime += Time.deltaTime;
        }       

        if (waitTime >= .5f)
        {
            lightSource.enabled = false;
        }
        if (waitTime >= 1f)
        {
            lightSource.enabled = true;
        }
        if (waitTime >= 1.5f)
        {
            lightSource.enabled = false;
        }
        if (waitTime >= 2f)
        {
            lightSource.enabled = true;
        }
        if(waitTime >= 3f)
        {
            playClip = true;
            lightSource.enabled = false;
            waitTime = 0f;
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            startTimer = true;
            flashlight.enabled = false;
            //print("Player passed trigger");
        }
    }
}
