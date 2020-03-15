using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteArea : MonoBehaviour
{
    public GameObject plane;
    public GameObject light1, light2, light3;
    public GameObject area1;
    // Start is called before the first frame update
    void Start()
    {
        plane.SetActive(false);
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            plane.SetActive(true);
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
            Destroy(area1);
        }
    }
}
