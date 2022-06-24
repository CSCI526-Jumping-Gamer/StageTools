using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RandomCards : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cardPanel;
    [SerializeField] TextMeshProUGUI[] cardText;
    private Card[] threeStarsCards; // 25%
    private Card[] twoStarsCards; // 50%
    private Card[] oneStarsCards; // 25%
    private List<Card> cards;

    int[] randCardNumber;

    void Awake()
    {
        cardPanel = GameObject.FindWithTag("CardPanel");
        randCardNumber = new int[] { Random.Range(1, 100), Random.Range(1, 100), Random.Range(1, 100) };
        threeStarsCards = new Card[] { ScriptableObject.CreateInstance<DoubleJump>() };// 25%
        twoStarsCards = new Card[] { ScriptableObject.CreateInstance<SlingshotHelper>() }; // 50%
        oneStarsCards = new Card[] { ScriptableObject.CreateInstance<SpeedUp>() }; // 25%
        cards = new List<Card>();
        cardPanel.SetActive(false);
        // gameObject.SetActive(false);
    }

    void Start()
    {

        // cardPanel.SetActive(true);
        // cardPanel.SetActive(false);
        // StartCoroutine(CardSelections());
        // cardPanel.SetActive(true);
        // Debug.Log("Pick a card!!");
        // getCards(0);
        // getCards(1);
        // getCards(2);
        PlayerController.instance.DisablePlayerInput();
        Invoke("StartCardPanel", 0.5f);
    }

    // IEnumerator CardSelections() {
    //     yield return new WaitForSeconds(1);
    //     cardPanel.SetActive(true);
    //     Debug.Log("Pick a card!!");
    //     getCards(0);
    //     getCards(1);
    //     getCards(2);

    // }

    void StartCardPanel()
    {
        cardPanel.SetActive(true);
        Debug.Log("Pick a card!!");
        getCards(0);
        getCards(1);
        getCards(2);
        Time.timeScale = 0f;
    }

    void getCards(int index)
    {
        Card currCard = null;
        if (randCardNumber[index] <= 25)
        { // 3 star
            currCard = threeStarsCards[Random.Range(0, threeStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;

        }
        else if (randCardNumber[index] <= 75)
        { // 2 star
            currCard = twoStarsCards[Random.Range(0, twoStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;

        }
        else
        { // 1 star
            currCard = oneStarsCards[Random.Range(0, oneStarsCards.Length - 1)];
            cardText[index].text = currCard.cardName;
        }
        cards.Add(currCard);

    }

    public void SelectFirstCard()
    {
        Debug.Log(cards[0].cardName);
        Inventory.instance.Add(cards[0]);

        cardPanel.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }
    public void SelectSecondCard()
    {
        Debug.Log(cards[1].cardName);
        Inventory.instance.Add(cards[1]);
        cardPanel.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }
    public void SelectThirdCard()
    {
        Debug.Log(cards[2].cardName);
        Inventory.instance.Add(cards[2]);
        cardPanel.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }

}
