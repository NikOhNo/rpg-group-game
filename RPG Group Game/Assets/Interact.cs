using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    bool Touching = false;
    Collider2D NPC;

    private void Update()
    {
        if(Touching == true)
        {
            Debug.Log("touching!!!");
            float interactInput = Input.GetAxisRaw("Interact");
            Debug.Log("InteractInput: " + interactInput);
            if (interactInput > 0)
            {
                Debug.Log("iantadndtnkasdtkl");
                NPC.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hello");
        if(collision.tag == "Interactable")
        {
            NPC = collision;
            Touching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("goodbye!");
        Touching = false;
        NPC = null;
    }
}

