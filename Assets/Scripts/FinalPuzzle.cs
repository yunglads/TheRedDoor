using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPuzzle : MonoBehaviour
{
    public GameObject doorObj;
    public Door door;
    bool cupboard1 = false;
    bool cupboard2 = false;
    bool cupboard11 = false;
    bool cupboard5 = false;
    bool doorUnlocked = false;

    public GameObject key;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;

    // Start is called before the first frame update
    void Start()
    {
        door = doorObj.GetComponent<Door>();
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cupboard1 && cupboard11 && cupboard2 && !cupboard5)
        {
            key.transform.position = spawn1.position;
            key.transform.rotation = spawn1.rotation;
            key.SetActive(true);
        }
        else if (cupboard1 && cupboard11 && !cupboard2 && cupboard5)
        {
            key.transform.position = spawn2.position;
            key.transform.rotation = spawn2.rotation;
            key.SetActive(true);
        }
        else if (cupboard1 && !cupboard11 && cupboard2 && cupboard5)
        {
            key.transform.position = spawn3.position;
            key.transform.rotation = spawn3.rotation;
            key.SetActive(true);
        }
        else if (!cupboard1 && cupboard11 && cupboard2 && cupboard5)
        {
            key.transform.position = spawn4.position;
            key.transform.rotation = spawn4.rotation;
            key.SetActive(true);
        }

        if (cupboard1 && cupboard11 && cupboard2 && cupboard5)
        {
            door.UnlockDoor();
            doorUnlocked = true;
        }

        if (doorUnlocked)
        {
            Destroy(GetComponent<FinalPuzzle>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cupboard 1" && Input.GetButtonDown("Interact"))
        {
            cupboard1 = true;
        }

        if (other.tag == "Cupboard 1-1" && Input.GetButtonDown("Interact"))
        {
            cupboard11 = true;
        }

        if (other.tag == "Cupboard 2" && Input.GetButtonDown("Interact"))
        {
            cupboard2 = true;
        }

        if (other.tag == "Cupboard 5" && Input.GetButtonDown("Interact"))
        {
            cupboard5 = true;
        }
    }
}
