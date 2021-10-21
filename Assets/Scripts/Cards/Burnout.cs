using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burnout : CardEffect
{
    bool removedCard = false;
    bool shouldPlay = false;
    internal override void Start() { base.Start(); special = true; }
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
                    if (removedCard)
                    {
                        if (hit.collider.gameObject.GetComponent<PosHolder>() && battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 0)
                        {
                            battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] = GetComponent<CardBehaviour>().team;
                            player.GetComponent<Animator>().SetBool("Looking", false);
                            player.GetComponent<Player>().playing = false;
                            player.cardsInHand.Remove(gameObject);
                            Destroy(gameObject);
                        }
                    }
                    else if (hit.collider.gameObject.TryGetComponent(out CardEffect cerd))
                    {
                        if (!cerd.special)
                        {
                            player.cardsInHand.Remove(cerd.gameObject);
                            Destroy(cerd.gameObject);
                            removedCard = true;
                        }
                    }

                }
            }
            

        }
        else foreach (GameObject card in player.cardsInHand)
        {
            if (!card.GetComponent<CardEffect>().special)
            {
                shouldPlay = true;
            }
        }
        if (!shouldPlay) player.playing = false;
    }
}
