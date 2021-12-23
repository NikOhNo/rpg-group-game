using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplayRecorder : MonoBehaviour
{
    private bool isInReplayMode;
    private int currentReplayIndex;
    public List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    PlayerGridMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerGridMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            isInReplayMode = !isInReplayMode;

            if (isInReplayMode)
            {

            }
            else
            {
                int nextIndex = currentReplayIndex + 1;

                if(nextIndex < actionReplayRecords.Count)
                {
                    SetTransform(nextIndex);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        actionReplayRecords.Add(new ActionReplayRecord { position = transform.position, horizontalInput = player.GetHorizontalInput(), verticalInput = player.GetVerticalInput() });
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;

        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.position;
    }
}
