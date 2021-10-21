using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : CardEffect
{
    //sbyte placeValue;
    internal override void Start() { base.Start();  special = false; }
    public override void Play()
    {
        player.GetComponent<Animator>().SetBool("Looking", true);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButton(0) && hit.collider.gameObject.GetComponent<PosHolder>())
            {
                if(battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 0)
                {
                    battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] = GetComponent<CardBehaviour>().team;
                    player.GetComponent<Animator>().SetBool("Looking", false);
                    player.GetComponent<Player>().playing = false;
                    player.GetComponent<Player>().normalPlayed = true;
                    player.cardsInHand.Remove(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
