using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect : MonoBehaviour
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
