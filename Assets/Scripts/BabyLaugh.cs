using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyLaugh : MonoBehaviour
{
    public GameObject baby;
    public GameObject player;
    public AudioSource babyAudio;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        babyAudio = baby.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            babyAudio.Play();
            baby.transform.Rotate(0, 0, -42);
            rb.constraints = RigidbodyConstraints.None;
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(gameObject.GetComponent<BabyLaugh>());
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject.GetComponent<BabyLaugh>());
        }
    }*/
}
