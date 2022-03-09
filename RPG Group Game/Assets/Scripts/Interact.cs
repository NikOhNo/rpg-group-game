using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    bool touching = false;
    bool interacting = false;
    Collider2D interactObject;

    /* Update
     * If the look point is touching another object, interactions can occur 
     * if the player provides the correct input and all conditions are met
     * interactObject will invoke the interacation of the object look point is touching
     */
    private void Update()
    {
        if(touching == true)
        {
            Debug.Log("touching!!!");
            float interactInput = Input.GetAxisRaw("Interact");
            Debug.Log("InteractInput: " + interactInput);
            if (interactInput > 0 && interacting != true && interactObject.GetComponent<Interactable>())
            {
                Debug.Log("iantadndtnkasdtkl");
                interactObject.GetComponent<Interactable>().DoInteraction();
                interacting = true;
            }
        }
    }

    /* upon colliding with a trigger of an object of tag "Interactable" 
     * sets interactObject to the collision object 
     * sets touching equal to true to allow interactions to occur
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hello");
        if(collision.tag == "Interactable")
        {
            interactObject = collision;
            touching = true;
        }
    }

    /* upon exiting a collision with a trigger of an object
     * sets interactObject to nothing
     * sets touching equal to false to prohibit interactions
     */
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("goodbye!");
        touching = false;
        interactObject = null;
    }

    public void SetInteractingFalse()
    {
        interacting = false;
    }
}

