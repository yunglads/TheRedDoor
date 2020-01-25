using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    //Vector3 portalForward;
    //Vector3 portalBackward;

    //public GameObject portalForwardObj;
    //public GameObject portalBackwardObj;

    public float waitTime = 0f;

    //public GameObject granny;
    //public GameObject grannyClone1;

    public bool playerIsOverlapping = false;
    //public bool enemyPassedPortal = false;
    //bool portalEntered = false;
    //bool enemyIsOverlapping = false;

    EnemyAI enemyAI;

    void Start()
    {
        //portalForward = portalForwardObj.transform.position;
        //portalBackward = portalBackwardObj.transform.position;

        enemyAI = GameObject.FindObjectOfType<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 playerToPortal = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, playerToPortal);

            if (dotProduct < 0f)
            {
                float rotationDifference = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDifference += 180;
                player.Rotate(Vector3.up, rotationDifference);

                Vector3 postionOffset = Quaternion.Euler(0f, rotationDifference, 0) * playerToPortal;
                player.position = reciever.position + postionOffset;

                playerIsOverlapping = false;
            }
        }

        /*if (waitTime >= .01f)
        {
            granny.GetComponent<NavMeshAgent>().enabled = true;
            granny.GetComponent<NavMeshAgent>().SetDestination(portalForward.position);
            waitTime = 0f;
        }*/

        /*if (enemyIsOverlapping)
        {
            Vector3 enemyToPortal = enemy.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, enemyToPortal);

            if (dotProduct < 0f)
            {
                float rotationDifference = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDifference += 180;
                enemy.Rotate(Vector3.up, rotationDifference);

                Vector3 postionOffset = Quaternion.Euler(0f, rotationDifference, 0) * enemyToPortal;
                enemy.position = reciever.position + postionOffset;

                enemyIsOverlapping = false;
            }
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            //portalEntered = true;
        }

        /*if (other.tag == "Enemy" && !enemyPassedPortal)
        {
            granny.GetComponent<NavMeshAgent>().enabled = false;
            granny.transform.position = portalForward;
            waitTime += Time.deltaTime;
            //gameObject.GetComponent<BoxCollider>().enabled = false;
            //enemyPassedPortal = true;
            print("enemy teleported forward");
        }*/

        /*if (other.tag == "Enemy" && enemyPassedPortal)
        {
            granny.GetComponent<NavMeshAgent>().enabled = false;
            granny.transform.position = portalBackward.position;
            //enemyPassedPortal = false;
            print("enemy teleported backward");
        }*/
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }

        if (other.tag == "Enemy")
        {
            //enemyPassedPortal = true;
        }
    }
}
