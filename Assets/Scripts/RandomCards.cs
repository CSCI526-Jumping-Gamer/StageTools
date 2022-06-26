using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RandomCards : MonoBehaviour
{
    List<Card> threeStarCards; // 25%
    List<Card> twoStarCards; // 50%
    List<Card> oneStarCards; // 25%
    List<Card> cards = new List<Card>();
    int cardsLength = 3;
    List<int> cardScores;
    int bias = 0;

    [SerializeField] GameObject wrapper;
    [SerializeField] List<TextMeshProUGUI> cardText;
    
    void Start() {
        InitializeCardPool();
        cardScores = calculateCardScores();
        PlayerController.instance.DisablePlayerInput();
        Invoke("StartCardPanel", 0.2f);
    }

    void InitializeCardPool() {
        oneStarCards = new List<Card> {
            ScriptableObject.CreateInstance<SpeedUp>(), 
            ScriptableObject.CreateInstance<HighJump>(), 
            ScriptableObject.CreateInstance<SingleUseShield>(),
            ScriptableObject.CreateInstance<LightWeight>(),
            ScriptableObject.CreateInstance<RopeClimber>() }; // 25%

        twoStarCards = new List<Card> {
            ScriptableObject.CreateInstance<SlingshotHelper>(),
            ScriptableObject.CreateInstance<DoubleJump>(),
            ScriptableObject.CreateInstance<Flash>(),
            ScriptableObject.CreateInstance<LunarGravity>(),
            ScriptableObject.CreateInstance<ThreeTimesShield>() }; // 50%

        threeStarCards = new List<Card> {
            ScriptableObject.CreateInstance<ZeroGravity>(),
            ScriptableObject.CreateInstance<Invincible>(),
            ScriptableObject.CreateInstance<TripleJump>() };// 25%
    }

    List<int> calculateCardScores() {
        if (Scoreboard.score == 3) {
            bias = 50;
        } else if (Scoreboard.score == 2) {
            bias = 20;
        } else {
            bias = 0;
        }

        return new List<int> { 
            Random.Range(1, 100) + bias, 
            Random.Range(1, 100) + bias, 
            Random.Range(1, 100) + bias };
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
            // 1 star
            currCard = oneStarCards[Random.Range(0, oneStarCards.Count)];
            oneStarCards.Remove(currCard);
            
        } else if (cardScores[index] <= 75) { 
            // 2 star
            currCard = twoStarCards[Random.Range(0, twoStarCards.Count)];
            twoStarCards.Remove(currCard);
        } else { 
            // 3 star
            currCard = threeStarCards[Random.Range(0, threeStarCards.Count)];
            threeStarCards.Remove(currCard);
        }


        cardText[index].text = currCard.cardName;
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
