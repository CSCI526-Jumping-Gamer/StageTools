using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// public delegate void EnableCard(int i);
// public delegate void DisableCard(int i);


public class PlayerCard : MonoBehaviour
{
    // Start is called before the first frame update
    public int cardNumber = 1;
    // 0 - no card
    // 1 - MagnetHelper
    [SerializeField] Card1MagnetHelper card1;
    [SerializeField] Card2DoubleJump card2;
    [SerializeField] Card3SpeedUp card3;
    // [SerializeField] CardTimer cardTimer;
    
// Input card number here
    public delegate void EnableCard(int i);
    public delegate void DisableCard(int i);
    // public delegate string PutCardName(int i);
    // public delegate float PutCardTime(int i);
    // public delegate int PutCardRank(int i);
    public EnableCard enableCard;
    public DisableCard disableCard;
    // public delegate void TestDelegate();
    // public TestDelegate testDelegate;
    // public PutCardName putCardName;
    // public PutCardTime putCardTime;
    // public PutCardRank putCardRank;
    string cardName;
    float cardTime;
    int cardRank;
    // 1 - 1 stars
    // 2 - 2 stars
    // 3 - 3 stars
    public bool isUsingCard;
    int cardState = 0;
    // 0 - no card
    // 1 - have card but didn't use yet
    // 2 - have card and using it
    // 3 - have card and already used

    void Awake() {
        cardState = 1;
    }
    void Start()
    {
        // testDelegate();
        // enableCard(cardNumber);
        // cardName = putCardName(cardNumber);
        // cardTime = putCardTime(cardNumber);
        // cardRank = putCardRank(cardNumber);
        // Debug.Log(card1);
        InitiateCard();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitiateCard() {
        switch (cardNumber) {
            case 1:
                cardState = 1;
                SetCardInfo(card1.cardName, card1.cardTime, card1.cardRank);
                break;
            case 2:
                cardState = 1;
                SetCardInfo(card2.cardName, card2.cardTime, card2.cardRank);
                break;
            case 3:
                cardState = 1;
                SetCardInfo(card3.cardName, card3.cardTime, card3.cardRank);
                break;
            default:
                cardState = 0;
                break;
        }
    }
    public void StartCard() {
        if (cardState == 1) {
            CardEnabled();
            cardState = 2;
        }
    }
    public void EndCard() {
        if (cardState == 2) {
            CardDisabled();
            cardState = 3;
        }
    }

    void SetCardInfo(string cardName, float cardTime, int cardRank) {
        this.cardName = cardName;
        this.cardTime = cardTime;
        this.cardRank = cardRank;
    }
    public void SetCard(int cardNumber) {
        this.cardNumber = cardNumber;
    }
    public void SetCardState(int cardState) {
        this.cardState = cardState;
    }
    public void CardEnabled() {
        enableCard(cardNumber);
    }
    public void CardDisabled() {
        disableCard(cardNumber);
    }
    public int GetCardNumber() {
        return cardNumber;
    }
    public string GetCardName() {
        return cardName;
    }
    public float GetCardTime() {
        return cardTime;
    }
    public int GetCardRank() {
        return cardRank;
    }
    public int GetCardState() {
        return cardState;
    }
}
