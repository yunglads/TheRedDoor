using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    Animator anim;
    KeyInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        inventory = FindObjectOfType<KeyInventory>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && inventory.key1Collected && inventory.key2Collected && inventory.key3Collected && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isOpening", true);
            print("opening door");
        }
    }

    void StopAnim()
    {
        anim.SetBool("isOpen", true);
    }
}
