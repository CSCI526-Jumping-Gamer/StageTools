using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RandomCards : MonoBehaviour
{
    Card[] threeStarCards; // 25%
    Card[] twoStarCards; // 50%
    Card[] oneStarCards; // 25%
    List<Card> cards;
    int cardsLength = 3;
    int[] cardScores;

    [SerializeField] GameObject wrapper;
    [SerializeField] TextMeshProUGUI[] cardText;
    
    void Awake()
    {
        cardScores = calculateCardScores();

        oneStarCards = new Card[] {
            ScriptableObject.CreateInstance<SpeedUp>(), 
            ScriptableObject.CreateInstance<HighJump>(), 
            ScriptableObject.CreateInstance<SingleUseShield>(),
            ScriptableObject.CreateInstance<LightWeight>(),
            ScriptableObject.CreateInstance<RopeClimber>() }; // 25%

        twoStarCards = new Card[] {
            ScriptableObject.CreateInstance<SlingshotHelper>(),
            ScriptableObject.CreateInstance<DoubleJump>(),
            ScriptableObject.CreateInstance<Flash>(),
            ScriptableObject.CreateInstance<LunarGravity>(),
            ScriptableObject.CreateInstance<ThreeTimesShield>() }; // 50%

        threeStarCards = new Card[] {
            ScriptableObject.CreateInstance<ZeroGravity>(),
            ScriptableObject.CreateInstance<Invincible>() };// 25%
        
        cards = new List<Card>();
    }

    void Start() {
        PlayerController.instance.DisablePlayerInput();
        Invoke("StartCardPanel", 0.2f);
    }

    int[] calculateCardScores() {
        // return new int[] { 
        //     Random.Range(1, 100), 
        //     Random.Range(1, 100), 
        //     Random.Range(1, 100) };
        return new int[] { 
            0,0,0 };
    }

    public void StartCardPanel() {
        wrapper.SetActive(true);

        for (int i = 0; i < cardsLength; i++) {
            drawCard(i);
        }

        Time.timeScale = 0f;
    }

    void drawCard(int index) {
        Card currCard = null;

        if (cardScores[index] <= 25) { 
            // 3 star
            currCard = threeStarCards[Random.Range(0, threeStarCards.Length)];
            cardText[index].text = currCard.cardName;
        } else if (cardScores[index] <= 75) { 
            // 2 star
            currCard = twoStarCards[Random.Range(0, twoStarCards.Length)];
            cardText[index].text = currCard.cardName;
        } else { 
            // 1 star
            currCard = oneStarCards[Random.Range(0, oneStarCards.Length)];
            cardText[index].text = currCard.cardName;
        }

        cards.Add(currCard);
    }

    public void SelectFirstCard(Button button) {
        Inventory.instance.Add(cards[0]);
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }
    public void SelectSecondCard() {
        Inventory.instance.Add(cards[1]);
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    } 
    public void SelectThirdCard() {
        Inventory.instance.Add(cards[2]);
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }

}
