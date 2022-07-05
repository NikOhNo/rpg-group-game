using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    public float timeToMove = 0.2f;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving && CheckAhead(Vector3.up))
        {
            StartCoroutine(MovePlayer(Vector3.up));
            SetMovingAnimations(0f, 1f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !isMoving && CheckAhead(Vector3.down))
        {
            StartCoroutine(MovePlayer(Vector3.down));
            SetMovingAnimations(0f, -1f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isMoving && CheckAhead(Vector3.left))
        {
            StartCoroutine(MovePlayer(Vector3.left));
            SetMovingAnimations(-1f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !isMoving && CheckAhead(Vector3.right))
        {
            StartCoroutine(MovePlayer(Vector3.right));
            SetMovingAnimations(1f, 0f);
        }
        else if (!isMoving)
        {
            SetAnimationsFalse();
        }
    }

    private void SetAnimationsFalse()
    {
        animator.SetFloat("vertical input", 0f);
        animator.SetFloat("horizontal input", 0f);
        animator.SetBool("moving", false);
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0f;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private bool CheckAhead(Vector3 direction)
    {
        return !Physics2D.OverlapCircle(transform.position + direction, .2f, LayerMask.GetMask("StopMovement"));
    }

    private void SetMovingAnimations(float hinput, float vinput)
    {
        animator.SetFloat("horizontal input", hinput);
        animator.SetFloat("vertical input", vinput);
        animator.SetBool("moving", true);
    }

    public Vector3 GetPostion()
    {
        return transform.position;
    }
    public float GetHInput()
    {
        return animator.GetFloat("horizontal input");
    }
    public float GetVInput()
    {
        return animator.GetFloat("vertical input");
    }
    public bool GetMoving()
    {
        return animator.GetBool("moving");
    }
}
