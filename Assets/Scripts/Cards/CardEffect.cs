using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class CardEffect : NetworkBehaviour
{
    internal bool special;
    internal BattleSystem battleSystem;
    internal Player player;
    // Start is called before the first frame update
    virtual internal void Start()
    {
        player = GetComponentInParent<Player>(); 
        battleSystem = FindObjectOfType<BattleSystem>();
    }

    // Update is called once per frame
    public abstract void Play();
}
