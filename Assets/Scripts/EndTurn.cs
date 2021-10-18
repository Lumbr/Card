using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public Player player;
    public void OnButtonClick()
    {
        Debug.Log(player.team);
        if(player.team == 1)
        {
            FindObjectOfType<BattleSystem>().state = BattleState.P2TURN;
        }
        else
        {
            FindObjectOfType<BattleSystem>().state = BattleState.P1TURN;
        }
    }
}
