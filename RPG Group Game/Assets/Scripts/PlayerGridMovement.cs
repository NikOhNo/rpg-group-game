using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public Animator anim;

    LineCoordinates playerFollowing;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        playerFollowing = FindObjectOfType<LineCoordinates>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        /* this code uses unity's built in input to check if its being pressed
         * if the input is being pressed, checks whether it is horizontal or verticle
         * next checks if there is an object ahead that stops movement with an overlap circle
         * depending on that, it will place a move point ahead for the character to follow
         * movepoint is also never allowed to be more than one unit ahead than character
         * once character is within .05f of the movepoint the movepoint can move again
         * moving bool will be set to true when character is not on movepoint and heading towards it
         * moving bool set to false when character is standing still on anim bool
         * 
         * CAN DISABLE DIAGONAL MOVEMENT BY PUTTING ELSE IF BETWEEN HORIZONTAL AND VERTICLE
         */
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f){
            bool horizontalInput = Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f;
            bool verticalInput = Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f;
            if (horizontalInput)
            {
                anim.SetFloat("vertical input", 0f);
                if (CheckAheadHorizontal())
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    anim.SetFloat("horizontal input", Input.GetAxisRaw("Horizontal"));
                    playerFollowing.GiveCoord(transform.position);
                    playerFollowing.DeleteCoord();
                }
                else
                {
                    anim.SetFloat("horizontal input", 0f);
                    anim.SetBool("moving", false);
                }
            }
            else if (verticalInput)
            {
                anim.SetFloat("horizontal input", 0f);
                if (CheckAheadVertical())
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    anim.SetFloat("vertical input", Input.GetAxisRaw("Vertical"));
                    playerFollowing.GiveCoord(transform.position);
                    playerFollowing.DeleteCoord();
                }
                else
                {
                    anim.SetFloat("vertical input", 0f);
                    anim.SetBool("moving", false);
                }
            }

            if (!horizontalInput && !verticalInput)
            {
                anim.SetBool("moving", false);
                anim.SetFloat("horizontal input", 0f);
                anim.SetFloat("vertical input", 0f);
            }
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }

    public bool GetMoving()
    {
        return anim.GetBool("moving");
    }

    public bool CheckAheadVertical()
    {
        return !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement);
    }

    public bool CheckAheadHorizontal()
    {
        return !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement);
    }

    public float GetHorizontalInput()
    {
        return anim.GetFloat("horizontal input");
    }

    public float GetVerticalInput()
    {
        return anim.GetFloat("vertical input");
    }
}
