using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplayFollower : MonoBehaviour
{
    private bool isInReplayMode;
    private int currentReplayIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetTransform(int index)
    {
        currentReplayIndex = index;

        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.position;
    }
}
