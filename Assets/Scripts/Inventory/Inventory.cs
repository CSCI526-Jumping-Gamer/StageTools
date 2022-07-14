using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Card activatingCard;
    public static Inventory instance;
    // public List<Card> cards = new List<Card>();
    public Dictionary<int, Card> cards = new Dictionary<int, Card>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory;");
            return;
        }

        instance = this;
    }

    public void Add(Card card)
    {
        if (!cards.ContainsKey(0))
        {
            cards.Add(0, card);
        }
        else if (cards.ContainsKey(0) && !cards.ContainsKey(1))
        {
            cards.Add(1, card);
        }
    }

    public void Remove(int i)
    {
        // int temp = -1;
        // foreach (KeyValuePair<int, Card> x in cards) {
        //     if (x.Value == card) {
        //         temp = x.Key;
        //         break;
        //     } 
        // }
        // if (temp != -1) {
        //     cards.Remove(temp);
        // }
        cards.Remove(i);
    }

    public Card GetCard(int i)
    {
        Card card = null;
        if (cards.TryGetValue(i, out card))
        {
            activatingCard = card;
            Remove(i);
            return card;
        }
        return null;
    }
    public Card SearchHelper()
    {
        foreach (KeyValuePair<int, Card> x in cards)
        {
            if (x.Value.GetType() == typeof(SlingshotHelper))
            {
                return x.Value;
            }
        }
        return null;
    }
}
