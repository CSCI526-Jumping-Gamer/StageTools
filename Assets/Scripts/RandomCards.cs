using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class RandomCards : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cardPanel;
    [SerializeField] TextMeshProUGUI[] cardText;
    private Card[] threeStarsCards; // 25%
    private Card[] twoStarsCards; // 50%
    private Card[] oneStarsCards; // 25%
    private List<Card> cards;
    int[] randCardNumber;
    
    void Awake() {
        // cardPanel = GameObject.FindWithTag("Cards");
        cardPanel.SetActive(false);
        randCardNumber = new int[]{ Random.Range(1, 100), Random.Range(1, 100), Random.Range(1, 100)};
        threeStarsCards = new Card[]{ ScriptableObject.CreateInstance<DoubleJump>()};// 25%
        twoStarsCards = new Card[]{ ScriptableObject.CreateInstance<SlingshotHelper>()}; // 50%
        oneStarsCards = new Card[]{ ScriptableObject.CreateInstance<SpeedUp>()}; // 25%
        cards = new List<Card>();
    }

    void Start()
    {
        StartCoroutine(CardSelections());
    }

    IEnumerator CardSelections() {
        
        yield return new WaitForSeconds(1);
        cardPanel.SetActive(true);
        Debug.Log("Pick a card!!");
        getCards(0);
        getCards(1);
        getCards(2);

    }

    void getCards(int index) {
        Card currCard = null;
        if (randCardNumber[index] <= 25) { // 3 star
            currCard = threeStarsCards[Random.Range(0, threeStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;
            
        } else if (randCardNumber[index] <= 75) { // 2 star
            currCard = twoStarsCards[Random.Range(0, twoStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;
            
        } else { // 1 star
            currCard = oneStarsCards[Random.Range(0, oneStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;
        }
        cards.Add(currCard);

    }

    public void SelectFirstCard() {
        Debug.Log(cards[0].cardName);
        cardPanel.SetActive(false);
    }
    public void SelectSecondCard() {
        Debug.Log(cards[1].cardName);
        cardPanel.SetActive(false);
    }
    public void SelectThirdCard() {
        Debug.Log(cards[2].cardName);
        cardPanel.SetActive(false);
    }

}
