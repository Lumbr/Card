using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    PhotonView view;
    public Button endTurn;
    public sbyte team;
    public CardBehaviour cardPrefab;
    public List<Card> cardsInDeck;
    public List<GameObject> cardsInHand;
    CardEffect cardInPlay;
    [HideInInspector] public bool normalPlayed = false;
    [HideInInspector] public bool playing = false;
    public RuntimeAnimatorController player1, player2;
    public void Awake()
    {
        if (team == 1) GetComponent<Animator>().runtimeAnimatorController = player1;
        else if (team == -1) GetComponent<Animator>().runtimeAnimatorController = player2;
        view = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (!view.IsMine)
        {
            GetComponent<Camera>().enabled = false;
            GetComponent<AudioListener>().enabled = false;
        }
        if (cardsInHand.Count <= 0) return;
        float count = 0;
        foreach(GameObject card in cardsInHand)
        {
            //card.TryGetComponent(out CardEffect effect);
            card.transform.localPosition = new Vector3(cardsInHand.Count / 2 - count, -2.5f, 6 + count / 16);
            card.transform.localEulerAngles = new Vector3(90 - cardsInHand.Count + count * 2, 270, 90);
            count++;
        }
    }
    public void Draw(byte amount)
    {
        //if (!view.IsMine) return;
        endTurn.GetComponent<EndTurn>().team = team;
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
    }
    public void Turn()
    {
        //if(!view.IsMine) return;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<CardEffect>() && cardsInHand.Contains(hit.collider.gameObject))
            {
                cardInPlay = hit.collider.gameObject.GetComponent<CardEffect>();
                if (normalPlayed && !cardInPlay.special) { playing = false; return; }
                playing = true;
            }
        }
        if (cardInPlay && playing)
        {
            cardInPlay.Play();
        }
    }
}
