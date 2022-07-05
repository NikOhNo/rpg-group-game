using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPlayer : MonoBehaviour
{
    // public GameObject leader; // the game object to follow - assign in inspector
    public int steps; // number of steps to stay behind - assign in inspector

    private Queue<ActionReplayRecord> record = new Queue<ActionReplayRecord>();
    private GridMovement player;
    private Animator anim;


    private void Start()
    {
        player = FindObjectOfType<GridMovement>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // record position of leader
        if (player.GetMoving())
        {
            record.Enqueue(new ActionReplayRecord { position = player.GetPostion(), horizontalInput = player.GetHInput(), verticalInput = player.GetVInput(), moving = player.GetMoving() });
        }
        else
        {
            anim.SetBool("moving", false);
        }

        // remove last position from the record and use it for our own
        if ((record.Count > steps) && player.GetMoving())
        {
            ActionReplayRecord ARR = record.Dequeue();

            // copy leader by setting variables to ARR's values
            transform.position = ARR.position;
            anim.SetFloat("horizontal", ARR.horizontalInput);
            anim.SetFloat("vertical", ARR.verticalInput);
            anim.SetBool("moving", ARR.moving);
        }
    }
}
