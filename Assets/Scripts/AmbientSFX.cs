using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSFX : MonoBehaviour
{
    public AudioClip footsteps;
    public AudioClip creaking;

    public int minWaitTime = 60;[Tooltip("Min time in seconds before playing SFX. By default set to 60 seconds")]
    public int maxWaitTime = 240; [Tooltip("Max time in seconds before playing SFX. By default set to 240 seconds")]

    float randomTime;
    float waitTime;
    int RandomInt;
    bool playingSound = false;
    bool setRandomTimer = false;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!setRandomTimer)
        {
            SetRandomSFX();
            setRandomTimer = true;
        }

        if (!playingSound)
        {
            SetRandomTimer();
            return;
        }    

        if (playingSound)
        {
            waitTime += Time.fixedDeltaTime;

            if (waitTime >= randomTime && waitTime <= randomTime + .02f)
            {
                source.Play();
            }

            if (waitTime >= randomTime + 5f)
            {
                waitTime = 0;
                setRandomTimer = false;
                playingSound = false;
            }
        }
    }

    void SetRandomTimer()
    {
        randomTime = Random.Range(minWaitTime, maxWaitTime);
        playingSound = true;
        print("Timer set to: " + randomTime);
    }

    void SetRandomSFX()
    {
        RandomInt = Random.Range(0, 2);

        if (RandomInt == 0)
        {
            source.clip = footsteps;
            //print("Sound set to Footsteps");
        }

        else if (RandomInt == 1)
        {
            source.clip = creaking;
            //print("Sound set to Creaking");
        }
        return;
    }
}
