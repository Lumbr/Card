using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public Player player;
    public void OnButtonClick()
    {
        if (player.playing) return;
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
