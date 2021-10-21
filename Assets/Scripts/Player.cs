using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public EndTurn endTurn;
    public byte team;
    public CardBehaviour cardPrefab;
    public List<Card> cardsInDeck;
    public List<GameObject> cardsInHand;
    CardEffect cardInPlay;
    public bool normalPlayed = false, playing = false, startTurn = false;
    public RuntimeAnimatorController player1, player2;
    public void Awake()
    {
        if (team == 1) GetComponent<Animator>().runtimeAnimatorController = player1;
        else if (team == 2) GetComponent<Animator>().runtimeAnimatorController = player2;
        cardsInDeck = cardsInDeck.OrderBy(a => Guid.NewGuid()).ToList();
        
    }
    private void Update()
    {
        if (cardsInHand.Count <= 0) return;
        float count = 0;
        //Debug.Log(Input.mousePosition.y);
        foreach(GameObject card in cardsInHand)
        {
            //card.TryGetComponent(out CardEffect effect);
            if(Input.mousePosition.y <= Screen.height/8) card.transform.localPosition = new Vector3(1.7f*(cardsInHand.Count / 2 - count), -2.3f, 6 + count / 16);
            else card.transform.localPosition = new Vector3(1.7f*(cardsInHand.Count / 2 - count), -4f, 6 + count / 16);
            card.transform.localEulerAngles = new Vector3(90 - cardsInHand.Count + count * 2, 270, 90);
            count++;
        }
    }
    public void Draw(byte amount)
    {
        Awake();
        if (cardsInDeck.Count >= amount)
        {
            for(int i = 1; i <= amount; i++)
            {
                CardBehaviour instance = Instantiate(cardPrefab, gameObject.transform);
                instance.card = cardsInDeck.Last();
                instance.team = team;
                cardsInHand.Add(instance.gameObject);
                cardsInDeck.Remove(cardsInDeck.Last());
            }
        }
        else
        {
            if (team == 1) FindObjectOfType<BattleSystem>().state = BattleState.P2WIN;
            else if (team == 2) FindObjectOfType<BattleSystem>().state = BattleState.P1WIN;
        }
    }
    public void Turn()
    {
        if (startTurn)
        {
            Draw(1);
            startTurn = false;
        }
        if (cardInPlay && playing)
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButton(1))
            {
                GetComponent<Animator>().SetBool("Looking", false);
                playing = false;
                return;
            }
            cardInPlay.Play();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponent<CardEffect>() && cardsInHand.Contains(hit.collider.gameObject))
                {
                    cardInPlay = hit.collider.gameObject.GetComponent<CardEffect>();
                    if (normalPlayed && !cardInPlay.special) playing = false;
                    else playing = true;
                    System.Threading.Thread.Sleep(100);
                    return;
                }
            }
        }
        

    }

}
