using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceX : CardBehaviour
{

    public override void Start() { base.Start(); special = false; }
    public override void Play()
    {
        base.Play();
        Camera.main.GetComponent<Animator>().SetBool("Looking", true);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<PosHolder>())
            {
                if(battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] == 0)
                {
                    battleSystem.grid[hit.collider.gameObject.GetComponent<PosHolder>().y - 1, hit.collider.gameObject.GetComponent<PosHolder>().x - 1] = 1;
                    Camera.main.GetComponent<Animator>().SetBool("Looking", false);
                    Camera.main.GetComponent<Player>().playing = false;
                    Camera.main.GetComponent<Player>().normalPlayed = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
