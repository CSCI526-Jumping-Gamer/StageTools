using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Card> cards = new List<Card>();
    
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one inventory;");
            return;
        }

        instance = this;

        // Add(ScriptableObject.CreateInstance<DoubleJump>());
    }

    public void Add(Card card) {
        cards.Add(card);
    }

    public Card Remove(Card card) {
        cards.Remove(card);
        return card;
    }

    public Card GetFirstCard() {
        if (cards.Count > 0) {
            return cards[0];
        }
        
        return null;
    }
}
