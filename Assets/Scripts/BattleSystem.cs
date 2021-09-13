using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public enum BattleState { WAITING, START, P1TURN, P2TURN, P1WIN, P2WIN}

public class BattleSystem : NetworkBehaviour
{
    public Player player1, player2;
    public List<GameObject> xs, os;
    public BattleState state = BattleState.WAITING;
    public sbyte[,] grid = new sbyte[,] {
                                            {0,0,0},
                                            {0,0,0},
                                            {0,0,0}};

    private void FixedUpdate()
    {
        if (state == BattleState.WAITING && player1 != null && player2 != null)
        {
            state = BattleState.START;
        }
        else if(FindObjectsOfType<Player>().Length == 2 && state == BattleState.WAITING)
        {
            player1 = FindObjectsOfType<Player>()[0].team == 1 ? FindObjectsOfType<Player>()[0] : FindObjectsOfType<Player>()[1];
            player2 = FindObjectsOfType<Player>()[0].team == -1 ? FindObjectsOfType<Player>()[0] : FindObjectsOfType<Player>()[1];
        }

        if (state == BattleState.START) SetupBattle();
        byte count = 0;
        foreach (sbyte sign in grid)
        {
            switch (sign)
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
                player1.Turn();
                break;
            case BattleState.P2TURN:
                player2.Turn();
                break;
        }
        if (grid == new sbyte[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }
            || grid == new sbyte[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }
            || grid == new sbyte[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } }
            || grid == new sbyte[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 0, 1 } })
            state = BattleState.P1WIN;
        if (grid == new sbyte[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 0, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, 0 }, { -1, -1, -1 }, { 0, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { -1, -1, -1 } }
            || grid == new sbyte[3, 3] { { -1, 0, 0 }, { 0, -1, 0 }, { 0, 0, -1 } }
            || grid == new sbyte[3, 3] { { 0, 0, -1 }, { 0, -1, 0 }, { -1, 0, 0 } }
            || grid == new sbyte[3, 3] { { -1, 0, 0 }, { -1, 0, 0 }, { -1, 0, 0 } }
            || grid == new sbyte[3, 3] { { 0, -1, 0 }, { 0, -1, 0 }, { 0, -1, 0 } }
            || grid == new sbyte[3, 3] { { 0, 0, -1 }, { 0, 0, -1 }, { 0, 0, -1 } })
            state = BattleState.P2WIN;
    }
    void SetupBattle()
    {
        player1.Draw(2);
        player1.OnEnable();
        player2.Draw(2);
        player2.OnEnable();
        if (Random.Range(1, 3) == 1)
        {
            player1.normalPlayed = true;
            state = BattleState.P1TURN;
        }
        else
        {
            player2.normalPlayed = true;
            state = BattleState.P2TURN;
        }
    }
}
