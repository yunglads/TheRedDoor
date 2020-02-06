using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBreak : MonoBehaviour
{
    public Light lightSource;
    public Light flashlight;
    public GameObject enemyModel;
    AudioSource source;
    public AudioSource source2;
    public AudioClip lightBreak;
    public AudioClip spookySound;
    public BoxCollider collider1;
    public BoxCollider collider2;

    float waitTime;
    bool startTimer = false;
    bool playClip = false;
    bool playClip2 = false;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source2 = gameObject.GetComponent<AudioSource>();
        enemyModel.SetActive(false);
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
            Destroy(enemyModel);
        }

        if (playClip2)
        {
            playClip2 = false;
            source2.PlayOneShot(spookySound);
        }

        if (startTimer)
        {
            waitTime += Time.fixedDeltaTime;
        }       

        if (waitTime >= .5f)
        {
            lightSource.enabled = false;
        }
        if (waitTime >= 1f)
        {
            lightSource.enabled = true;
        }
        if (waitTime >= 1.5f && waitTime <= 1.55f)
        {
            lightSource.enabled = false;
            lightSource.color = Color.red;
            enemyModel.SetActive(true);
            playClip2 = true;
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
