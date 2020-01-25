using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sight : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    public float lineOfSightAngle;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, -1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log(hit);
        }

        if (hit.collider.gameObject.tag == "Player")
        {
            LineOfSight();
            print("Player in line of sight");
        }
    }

    void LineOfSight()
    {
        Vector3 targetDir = player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < lineOfSightAngle)
        {
            agent.SetDestination(player.position);
            //print("player in line of sight");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LineOfSight();
        }
    }
}
