using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, P1TURN, P2TURN, P1WIN, P2WIN}

public class BattleSystem : MonoBehaviour
{
    public Player Player1, Player2;
    public List<GameObject> xs, os;
    public BattleState state;
    public sbyte[,] grid = new sbyte[,] { 
                                            {0,0,0},
                                            {0,0,0},
                                            {0,0,0}};
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }
    private void Update()
    {
        byte count = 0;
        foreach(sbyte sign in grid)
        {
            switch(sign)
            {
                case 0:
                    xs[count].SetActive(false);
                    os[count].SetActive(false);
                    break;
                case 1:
                    xs[count].SetActive(true);
                    os[count].SetActive(false);
                    break;
                case -1:
                    xs[count].SetActive(false);
                    os[count].SetActive(true);
                    break;
            }
            count++;
        }
        switch (state)
        {
            case BattleState.P1TURN:
                Player1.Turn();
                break;
            case BattleState.P2TURN:
                Player2.Turn();
                break;
        }
        if (grid == new sbyte[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }) state = BattleState.P1WIN;
        else if (grid == new sbyte[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 0, 0, 0 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 0 }, { -1, -1, -1 }, { 0, 0, 0 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { -1, -1, -1 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, -1 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, -1 }, { 0, -1, 0 }, { -1, 0, 0 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { -1, 0, 0 }, { -1, 0, 0 }, { -1, 0, 0 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { 0, -1, 0 }, { 0, -1, 0 }, { 0, -1, 0 } }) state = BattleState.P2WIN;
        else if (grid == new sbyte[3, 3] { { 0, 0, -1 }, { 0, 0, -1 }, { 0, 0, -1 } }) state = BattleState.P2WIN;
    }
    void SetupBattle()
    {
        state = BattleState.P1TURN;
        //if (Random.Range(1, 3) == 1) state = BattleState.P1TURN;
        //else state = BattleState.P2TURN;
    }
    void Player1Turn()
    {
        //Player2Turn();
    }
    void Player2Turn()
    {
        //Player1Turn();
    }
}
