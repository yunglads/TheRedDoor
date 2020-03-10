using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyKey : MonoBehaviour
{
    public GameObject[] bodies;
    public GameObject enemy;
    //public GameObject key;
    AudioSource source;
    public bool keyPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);
        source = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < bodies.Length; i++)
            {
                Destroy(bodies[i].gameObject);
            }
            source.Play();
            keyPickedUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && keyPickedUp)
        {
            enemy.SetActive(true);
        }
    }
}
