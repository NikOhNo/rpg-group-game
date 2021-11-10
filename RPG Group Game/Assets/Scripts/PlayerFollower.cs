using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] [Range(0, 2)] int orderInParty;


    // Update is called once per frame
    void Update()
    {
        MoveFollower();
    }


    public void MoveFollower()
    {
        if(orderInParty < FindObjectOfType<LineCoordinates>().GiveCount())
        transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<LineCoordinates>().GetCoord(orderInParty), moveSpeed * Time.deltaTime);
    }
}
