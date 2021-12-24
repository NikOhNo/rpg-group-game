using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAnimations : MonoBehaviour
{
    public GameObject leader; // the game object to follow - assign in inspector
    public int steps; // number of steps to stay behind - assign in inspector
    public Animator anim;

    private Queue<ActionReplayRecord> record = new Queue<ActionReplayRecord>();
    private float horizontalInput;
    private float verticalInput;

    PlayerGridMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerGridMovement>();
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) ==  1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            // record position of leader
            record.Enqueue(new ActionReplayRecord { horizontalInput = player.GetHorizontalInput(), verticalInput = player.GetVerticalInput() });

            // remove last position from the record and use it for our own
            if (record.Count > steps)
            {
                ActionReplayRecord actionReplayRecord = record.Dequeue();
                horizontalInput = actionReplayRecord.horizontalInput;
                verticalInput = actionReplayRecord.verticalInput;

                anim.SetFloat("horizontal", horizontalInput);
                anim.SetFloat("vertical", verticalInput);
            }
        } else if (player.GetMoving() == false) {
            anim.SetFloat("horizontal", 0f);
            anim.SetFloat("vertical", 0f);
        }
    }
}
