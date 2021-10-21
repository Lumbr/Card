using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JestersSwitch : CardEffect
{
    public Vector2Int coord1 = new Vector2Int(20,20), coord2 = new Vector2Int(20, 20);
    public override void Play()
    {
        player.GetComponent<Animator>().SetBool("Looking", true);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButton(0) && hit.collider.gameObject.GetComponent<PosHolder>())
            {
                if (battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 1)
                {
                    if (coord1.x == 20) coord1 = new Vector2Int(hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1);
                }
                else if (battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 2)
                {
                    if (coord2.x == 20) coord2 = new Vector2Int(hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1);
                }
            }
        }
        if(coord1.x != 20 && coord2.x != 20)
        {
            byte val1 = battleSystem.grid[coord1.x, coord1.y];
            byte val2 = battleSystem.grid[coord2.x, coord2.y];
            battleSystem.grid[coord1.x, coord1.y] = val2;
            battleSystem.grid[coord2.x, coord2.y] = val1;
            player.GetComponent<Animator>().SetBool("Looking", false);
            player.GetComponent<Player>().playing = false;
            player.cardsInHand.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    internal override void Start() { base.Start(); special = true; }
}
