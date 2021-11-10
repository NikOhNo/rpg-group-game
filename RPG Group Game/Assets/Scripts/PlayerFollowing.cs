using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowing : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] [Range(0,2)] int orderInParty;

    static List<Vector3> lineCoords = new List<Vector3>();

    public void GiveCoord(Vector3 coordinate)
    {
        lineCoords.Insert(0, coordinate);
    }

    public void DeleteCoord()
    {
        if(lineCoords.Count > 3)
        {
            lineCoords.RemoveAt(3);
        }
    }

    public void MoveParty()
    {
        Debug.Log(lineCoords.Count);
        Debug.Log(orderInParty);
        Vector3.MoveTowards(transform.position, lineCoords[orderInParty], moveSpeed * Time.deltaTime);
    }
}
