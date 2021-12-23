using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] [Range(0, 2)] int orderInParty;
    float horizontalMotion;
    float verticalMotion;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        MoveFollower();
    }


    private void MoveFollower()
    {
        if(orderInParty < FindObjectOfType<LineCoordinates>().GiveCount())
        transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<LineCoordinates>().GetCoord(orderInParty), moveSpeed * Time.deltaTime);

        if(transform.position.x - FindObjectOfType<LineCoordinates>().GetCoord(orderInParty).x > 0)
        {
            horizontalMotion = -1;
        } else if (transform.position.x - FindObjectOfType<LineCoordinates>().GetCoord(orderInParty).x < 0)
        {
            horizontalMotion = 1;
        }
        if (transform.position.y - FindObjectOfType<LineCoordinates>().GetCoord(orderInParty).y > 0)
        {
            verticalMotion = -1;
        } else if (transform.position.y - FindObjectOfType<LineCoordinates>().GetCoord(orderInParty).y < 0)
        {
            verticalMotion = 1;
        }

        anim.SetFloat("horizontal", horizontalMotion);
        anim.SetFloat("vertical", verticalMotion);


    }
}
