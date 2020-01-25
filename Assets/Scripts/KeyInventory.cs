using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInventory : MonoBehaviour
{
    public Image i_key1;
    public Image i_key2;
    public Image i_key3;
    public Text t_key1;
    public Text t_key2;
    public Text t_key3;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public bool key1Collected = false;
    public bool key2Collected = false;
    public bool key3Collected = false;
    // Start is called before the first frame update
    void Start()
    {
        i_key1.enabled = false;
        i_key2.enabled = false;
        i_key3.enabled = false;
        t_key1.enabled = false;
        t_key2.enabled = false;
        t_key3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key 1" && Input.GetKeyDown(KeyCode.E))
        {
            key1Collected = true;
            i_key1.enabled = true;
            t_key1.enabled = true;
            Destroy(key1);
        }

        if (other.tag == "Key 2" && Input.GetKeyDown(KeyCode.E))
        {
            key2Collected = true;
            i_key2.enabled = true;
            t_key2.enabled = true;
            Destroy(key2);
        }

        if (other.tag == "Key 3" && Input.GetKeyDown(KeyCode.E))
        {
            key3Collected = true;
            i_key3.enabled = true;
            t_key3.enabled = true;
            Destroy(key3);
        }
    }
}
