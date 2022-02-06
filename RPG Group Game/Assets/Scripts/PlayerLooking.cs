using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    public Transform lookPoint;
    float horizontalLookDirection;
    float verticalLookDirection;

    void Start()
    {
        lookPoint.parent = null;
    }


    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontalInput) > 0)
        {
            verticalLookDirection = 0f;
            horizontalLookDirection = Mathf.Sign(horizontalInput);
        }
        else if (Mathf.Abs(verticalInput) > 0)
        {
            horizontalLookDirection = 0f;
            verticalLookDirection = Mathf.Sign(verticalInput);
        }
    lookPoint.position = transform.position + new Vector3(horizontalLookDirection, verticalLookDirection, 0f);
    }
}
