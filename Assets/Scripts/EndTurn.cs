using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour
{
    public sbyte team;
    public void OnButtonClick()
    {
        if(team == 1)
        {
            FindObjectOfType<BattleSystem>().state = BattleState.P2TURN;
        }
        else
        {
            FindObjectOfType<BattleSystem>().state = BattleState.P2TURN;
        }
    }
}
