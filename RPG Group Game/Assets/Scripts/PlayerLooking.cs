using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    public Transform lookPoint;
    float horizontalLookDirection;
    float verticalLookDirection;
    Animator anim;

    void Start()
    {
        anim = lookPoint.GetComponentInParent<Animator>();
        lookPoint.parent = null;
        
    }


    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontalInput) > 0)
        {
            // set vertical vars to 0
            verticalLookDirection = 0f;
            anim.SetFloat("look point y", 0f);

            // set horizontal vars to current hinput
            horizontalLookDirection = Mathf.Sign(horizontalInput);
            anim.SetFloat("look point x", Mathf.Sign(horizontalInput));
        }
        else if (Mathf.Abs(verticalInput) > 0)
        {
            // set horizontal vars to 0
            horizontalLookDirection = 0f;
            anim.SetFloat("look point x", 0f);

            // set vertical vars to current vinput
            verticalLookDirection = Mathf.Sign(verticalInput);
            anim.SetFloat("look point y", Mathf.Sign(verticalInput));
        }
    lookPoint.position = transform.position + new Vector3(horizontalLookDirection, verticalLookDirection, 0f);
    }
}
