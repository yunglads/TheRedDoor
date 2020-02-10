using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInTrigger : MonoBehaviour
{
    public GameObject closet;
    public GameObject enemy;

    private void Start()
    {
        //enemy.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            closet.SetActive(true);
            enemy.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            closet.SetActive(false);
        }
    }
}
