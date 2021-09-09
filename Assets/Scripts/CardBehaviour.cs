using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardBehaviour : MonoBehaviour
{
    public Card card;
    public TMP_Text title, description;
    public Image art;
    void Start()
    {
        title.text = card.name;
        description.text = card.description;
        art.sprite = card.art;
    }
    public void Play()
    {
        
    }

}
