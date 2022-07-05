using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    public GameObject[,] buttons = new GameObject[2,2];
    [SerializeField] GameObject selector;

    [SerializeField] GameObject topLeftBut;
    [SerializeField] GameObject topRightBut;
    [SerializeField] GameObject botLeftBut;
    [SerializeField] GameObject botRightBut;

    Vector2 menuPos = new Vector2(0, 0);

    private void Start()
    {
        buttons[0, 0] = topLeftBut;
        buttons[0, 1] = topRightBut;
        buttons[1, 0] = botLeftBut;
        buttons[1, 1] = botRightBut;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(menuPos.y + 1 < buttons.GetLength(1))
            {
                menuPos.y += 1;
                MoveSelector(buttons[Mathf.FloorToInt(menuPos.x), Mathf.FloorToInt(menuPos.y)].transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (menuPos.x + 1 < buttons.GetLength(0))
            {
                menuPos.x += 1;
                MoveSelector(buttons[Mathf.FloorToInt(menuPos.x), Mathf.FloorToInt(menuPos.y)].transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(menuPos.y - 1 >= 0)
            {
                menuPos.y -= 1;
                MoveSelector(buttons[Mathf.FloorToInt(menuPos.x), Mathf.FloorToInt(menuPos.y)].transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(menuPos.x - 1 >= 0)
            {
                menuPos.x -= 1;
                MoveSelector(buttons[Mathf.FloorToInt(menuPos.x), Mathf.FloorToInt(menuPos.y)].transform.position);
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("do interact!");
            buttons[Mathf.FloorToInt(menuPos.x), Mathf.FloorToInt(menuPos.y)].GetComponent<Interactable>().DoInteraction();
        }
    }

    private void MoveSelector(Vector3 newPos)
    {
        selector.transform.position = newPos;
    }
}
