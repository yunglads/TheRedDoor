using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    public Image noteImSorry;
    public Text noteText;

    bool inTrigger;
    bool noteOpen;

    // Start is called before the first frame update
    void Start()
    {
        noteImSorry.enabled = false;
        noteText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            noteImSorry.enabled = true;
            noteOpen = true;
            noteText.enabled = false;
        }

        if (noteOpen && Input.GetKeyUp(KeyCode.E))
        {
            noteImSorry.enabled = false;
            noteOpen = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        noteText.enabled = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Note1")
        {
            inTrigger = true;
            print("in trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Note1")
        {
            inTrigger = false;
        }   
    }
}
