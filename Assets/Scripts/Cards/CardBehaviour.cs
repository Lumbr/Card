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
    internal bool special;
    internal BattleSystem battleSystem;
    Player player;
    virtual public void Start()
    {
        player = GetComponentInParent<Player>();
        title.text = card.name;
        description.text = card.description;
        art.sprite = card.art;
        battleSystem = FindObjectOfType<BattleSystem>();
    }
    virtual public void Play()
    {
        
    }

}
