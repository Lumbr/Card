using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VladsUsefulScripts.Finders;
using UnityEngine.SceneManagement;

public enum BattleState { WAITING, START, P1TURN, P2TURN, P1WIN, P2WIN}

public class BattleSystem : MonoBehaviour
{
    public string p1Win, p2Win;
    public Player player1, player2;
    public List<GameObject> xs, os;
    public BattleState state = BattleState.WAITING;
    public byte[,] grid = new byte[3,3] {
                                            {0,0,0},
                                            {0,0,0},
                                            {0,0,0}};
    

    private void FixedUpdate()
    {
        if(state == BattleState.WAITING)
        {
            if (player1 != null && player2 != null)
            {
                state = BattleState.START;
            }
            else if (TryFindObjectsOfType(out Player[] players) ? players.Length == 2 : false)
            {
                player1 = players[0];
                player2 = players[1];
            }
        }
        
        
        if (state == BattleState.START) SetupBattle();
        byte count = 0;
        foreach (byte sign in grid)
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
                case 2:
                    xs[count].SetActive(false);
                    os[count].SetActive(true);
                    break;
            }
            count++;
        }
        
        switch (state)
        {
            case BattleState.P1TURN:
                player1.GetComponent<Camera>().enabled = true;
                player2.GetComponent<Camera>().enabled = false; 
                player1.GetComponent<AudioListener>().enabled = true;
                player2.GetComponent<AudioListener>().enabled = false;
                player1.endTurn.gameObject.SetActive(true);
                player2.endTurn.gameObject.SetActive(false);
                player2.startTurn = true;
                player2.normalPlayed = false;
                player1.Turn();
                break;
            case BattleState.P2TURN:
                player1.GetComponent<Camera>().enabled = false;
                player2.GetComponent<Camera>().enabled = true; 
                player1.GetComponent<AudioListener>().enabled = false;
                player2.GetComponent<AudioListener>().enabled = true;
                player1.endTurn.gameObject.SetActive(false);
                player2.endTurn.gameObject.SetActive(true);
                player1.startTurn = true;
                player1.normalPlayed = false;
                player2.Turn();
                break;
            case BattleState.P1WIN:
                SceneManager.LoadScene(p1Win);
                break;
            case BattleState.P2WIN:
                SceneManager.LoadScene(p2Win);
                break;
        }

        if (CheckGrid(1)) state = BattleState.P1WIN;
        if (CheckGrid(2)) state = BattleState.P2WIN;
        
    }
    bool CheckGrid(byte symbol)
    {
        if (grid[0, 0] == symbol && grid[1, 0] == symbol && grid[2, 0] == symbol ||
            grid[0, 1] == symbol && grid[1, 1] == symbol && grid[2, 1] == symbol ||
            grid[0, 2] == symbol && grid[1, 2] == symbol && grid[2, 2] == symbol ||
            grid[0, 0] == symbol && grid[1, 0] == symbol && grid[2, 0] == symbol ||
            grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 1] == symbol ||
            grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 1] == symbol ||
            grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol ||
            grid[0, 2] == symbol && grid[1, 1] == symbol && grid[2, 0] == symbol)

            return true;
        else return false;

    }
    void SetupBattle()
    {
        player1.team = 1;
        player2.team = 2;
        player1.Draw(2);
        player1.Awake();
        player2.Draw(2);
        player2.Awake();
        state = BattleState.P1TURN;
        /*if (Random.Range(1, 3) == 1)
        {
            //player1.normalPlayed = true;
            state = BattleState.P1TURN;
        }
        else
        {
            //player2.normalPlayed = true;
            state = BattleState.P2TURN;
        }*/
    }
}
