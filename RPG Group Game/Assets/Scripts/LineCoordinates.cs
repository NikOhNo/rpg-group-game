using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCoordinates : MonoBehaviour
{
    static List<Vector3> lineCoords = new List<Vector3>();

    public void GiveCoord(Vector3 coordinate)
    {
        lineCoords.Insert(0, coordinate);
    }
    public int GiveCount()
    {
        return lineCoords.Count;
    }

    public void DeleteCoord()
    {
        if(lineCoords.Count > 3)
        {
            lineCoords.RemoveAt(3);
        }
    }

    public Vector3 GetCoord(int index)
    {
        return lineCoords[index];
    }
}
