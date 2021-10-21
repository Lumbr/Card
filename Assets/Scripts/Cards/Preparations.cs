using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preparations : CardEffect
{
    internal override void Start() { base.Start(); special = false; }
    public override void Play()
    {
        player.GetComponent<Player>().normalPlayed = true;
        player.Draw(2);
        player.cardsInHand.Remove(gameObject);
        Destroy(gameObject);
    }
    
}
