using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactAction;

    // Invokes the interaction of the object this script is applied to
    public void DoInteraction()
    {
        interactAction.Invoke();
    }
}
