using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
{
    internal bool special;
    internal BattleSystem battleSystem;
    internal Player player;
    virtual internal void Start()
    {
        player = GetComponentInParent<Player>(); 
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    public abstract void Play();
}
