using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInTrigger : MonoBehaviour
{
    public GameObject closet;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            closet.SetActive(true);
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
