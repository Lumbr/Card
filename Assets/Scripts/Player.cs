using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CardBehaviour> cardsInDeck;
    public List<CardBehaviour> cardsInHand;
    CardBehaviour cardInPlay;
    [HideInInspector] public bool normalPlayed = false;
    [HideInInspector] public bool playing = false;
    private void Update()
    {
        if (cardsInHand.Count <= 0) return;
        float count = 0;
        foreach(CardBehaviour card in cardsInHand)
        {
            card.transform.localPosition = new Vector3(cardsInHand.Count / 2 - count, -2.5f, 6 + count / 16);
            card.transform.localEulerAngles = new Vector3(90 - cardsInHand.Count + count * 2, 270, 90);
            count++;
        }
    }
    public void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<CardBehaviour>())
            {
                cardInPlay = hit.collider.gameObject.GetComponent<CardBehaviour>();
                if (normalPlayed && !cardInPlay.special) { playing = false; return; }
                playing = true;
                cardsInHand.Remove(cardInPlay);
            }
        }
        if (cardInPlay && playing) cardInPlay.Play();
    }
}
