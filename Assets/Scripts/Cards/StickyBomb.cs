using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBomb : CardEffect
{
    bool shouldPlay = false;
    internal override void Start() { base.Start(); special = false; }
    public override void Play()
    {
        if (shouldPlay)
        {
            player.GetComponent<Animator>().SetBool("Looking", true);
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if(hit.collider.gameObject.GetComponent<PosHolder>() && battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 1)
                    {
                        battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] = 0;
                        player.GetComponent<Animator>().SetBool("Looking", false);
                        player.GetComponent<Player>().playing = false;
                        player.GetComponent<Player>().normalPlayed = true;
                        player.Draw(1);
                        player.cardsInHand.Remove(gameObject);
                        Destroy(gameObject);
                    }

                }
            }


        }
        else foreach (byte sign in battleSystem.grid)
            {
                if (sign == 1)
                {
                    shouldPlay = true;
                }
            }
        if (!shouldPlay) player.playing = false;
    }
}
