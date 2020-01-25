using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject player;
    public GameObject closet;
    public Transform hidingSpawnpoint;
    public Transform notHidingSpawnpoint;
    //bool isHiding = false;
    bool triggerEntered = false;
    float waitTime = 0;

    Sight sight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sight = FindObjectOfType<Sight>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !triggerEntered)
        {
            triggerEntered = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && triggerEntered)
        {
            player.transform.position = hidingSpawnpoint.position;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            sight.lineOfSightAngle = 0f;
            //isHiding = true;
            closet.GetComponent<MeshRenderer>().enabled = false;
            closet.GetComponent<BoxCollider>().enabled = false;
            print(sight.lineOfSightAngle);
            waitTime += Time.deltaTime;
        }

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && waitTime >= .03f)
        {
            player.transform.position = notHidingSpawnpoint.position;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            sight.lineOfSightAngle = 45f;
            waitTime = 0;
            //isHiding = false;
            closet.GetComponent<MeshRenderer>().enabled = true;
            closet.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            closet.GetComponent<MeshRenderer>().enabled = true;
            closet.GetComponent<BoxCollider>().enabled = true;
            triggerEntered = false;
            //isHiding = false;
        }
    }
}
