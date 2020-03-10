using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyScare : MonoBehaviour
{
    public GameObject deadBody;
    public GameObject lamp;
    public Light flashlight;
    AudioSource source;
    public GameObject body;
    public BoxCollider trigger;

    // Start is called before the first frame update
    void Start()
    {
        body.SetActive(false);
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lamp.SetActive(false);
            flashlight.enabled = false;
            source.Play();
            body.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(trigger);
            Destroy(gameObject.GetComponent<DeadBodyScare>());
        }
    }
}
