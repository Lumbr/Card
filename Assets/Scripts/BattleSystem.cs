using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, P1TURN, P2TURN, P1WIN, P2WIN}

public class BattleSystem : MonoBehaviour
{
    public GameObject Player1, Player2;
    [HideInInspector] public bool normalPlayed = false;
    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        if(Random.Range(1,3) == 1) Player1Turn();
        else Player2Turn();
    }
    void Player1Turn()
    {
        Player2Turn();
    }
    void Player2Turn()
    {
        Player1Turn();
    }
}
