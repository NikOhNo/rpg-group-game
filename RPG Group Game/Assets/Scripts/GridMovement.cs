using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Upward movement
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
            animator.SetBool("Up", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Up", false);
        }

        //Leftward movement
        else if(Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
            animator.SetBool("Left", true);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }

        //Downward movement
        if(Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
            animator.SetBool("Down", true);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Down", false);
        }

        //Rightward movement
        if(Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
            animator.SetBool("Right", true);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
