using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;
public class CardBehaviour : NetworkBehaviour
{
    public sbyte team;
    public Card card;
    public TMP_Text title, description;
    public Image art;
    bool start = true;
    public void Update()
    {
        if(start && card)
        {
            title.text = card.name;
            description.text = card.description;
            art.sprite = card.art;
            gameObject.AddComponent(Type.GetType(card.effect));
            start = false;
        }
    }


}
