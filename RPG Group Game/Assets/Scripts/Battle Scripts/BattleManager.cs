using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };

public class BattleManager : MonoBehaviour
{
    public BattleState state;

    [SerializeField] GameObject playerTurn;
    [SerializeField] GameObject enemyTurn;
    [SerializeField] GameObject winState;
    [SerializeField] GameObject loseState;

    private void Start()
    {
        state = BattleState.START;
    }

    private void Update()
    {
        if(state == BattleState.START && Input.GetKeyDown(KeyCode.Z))
        {
            ActivatePlayerTurn();
        }
    }

    private void ActivatePlayerTurn()
    {
        state = BattleState.PLAYERTURN;
        playerTurn.SetActive(true);
    }

    public void ActivateEnemyTurn() // implement enemyAttack
    {
        state = BattleState.ENEMYTURN;
        playerTurn.SetActive(false);
        enemyTurn.SetActive(true);
    }
}
