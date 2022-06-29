using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RandomCards : MonoBehaviour
{
    List<Card> threeStarCards; // 25%
    public List<Card> twoStarCards; // 50%
    List<Card> oneStarCards; // 25%
    List<Card> handCards;
    int cardsLength = 3;
    List<int> cardScores;
    
    int bias = 0;
    DeltaDnaEventHandler deltaDnaEventHandler;

    [SerializeField] GameObject wrapper;
    [SerializeField] List<TextMeshProUGUI> cardText;
    [SerializeField] List<Button> buttons;
    
    private void Awake() {
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
    }

    void Start() {
        InitializeCardPool();
        cardScores = calculateCardScores();
        PlayerController.instance.DisablePlayerInput();
        Invoke("StartCardPanel", 0.2f);
    }

    void InitializeCardPool() {
        InitializeOneStarCards();
        InitializeTwoStarCards();
        InitializeThreeStarCards();
    }

    void InitializeOneStarCards() {
        oneStarCards = new List<Card> {
            ScriptableObject.CreateInstance<SpeedUp>(), 
            ScriptableObject.CreateInstance<HighJump>(), 
            ScriptableObject.CreateInstance<SingleUseShield>(),
            ScriptableObject.CreateInstance<LightWeight>(),
            ScriptableObject.CreateInstance<RopeClimber>() }; // 25%
    }

    void InitializeTwoStarCards() {
        twoStarCards = new List<Card> {
            ScriptableObject.CreateInstance<SlingshotHelper>(),
            ScriptableObject.CreateInstance<DoubleJump>(),
            ScriptableObject.CreateInstance<Flash>(),
            ScriptableObject.CreateInstance<LunarGravity>(),
            ScriptableObject.CreateInstance<ThreeTimesShield>() }; // 50%
    }

    void InitializeThreeStarCards() {
        threeStarCards = new List<Card> {
            ScriptableObject.CreateInstance<ZeroGravity>(),
            ScriptableObject.CreateInstance<Invincible>(),
            ScriptableObject.CreateInstance<TripleJump>() };// 25%
    }

    void CheckCardPoolValidility() {
        if (oneStarCards.Count < 3) {
            InitializeOneStarCards();
        }

        if (twoStarCards.Count < 3) {
            InitializeTwoStarCards();
        }

        if (threeStarCards.Count < 3) {
            InitializeThreeStarCards();
        }
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
        handCards = new List<Card>();
        CheckCardPoolValidility();

        for (int i = 0; i < cardsLength; i++) {
            drawCard(i);
        }

        Time.timeScale = 0f;
    }

    void drawCard(int index) {
        Card currCard = null;

        if (cardScores[index] <= 25) {
            // 1 star
            // currCard = oneStarCards[Random.Range(0, oneStarCards.Count)];
            currCard = oneStarCards[2];
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
        SetCardColor(currCard.rank, index);
        Debug.Log("Card Rank: " + currCard.rank);
        handCards.Add(currCard);
        
        
    }



    void RemoveCardFromPool(Card card) {
        if (card.rank == 1) {
            oneStarCards.Remove(card);
        } else if (card.rank == 2) {
            twoStarCards.Remove(card);
        } else {
            threeStarCards.Remove(card);
        }
    }

    void AddCardBacktoPool() {
        for (int i = 0; i < handCards.Count; i++) {
            int rank = handCards[i].rank;

            if (rank == 1) {
                oneStarCards.Add(handCards[i]);
            } else if (rank == 2) {
                twoStarCards.Add(handCards[i]);
            } else {
                threeStarCards.Add(handCards[i]);
            }
        }
    }

    public void SelectFirstCard() {
        if (deltaDnaEventHandler) {
            deltaDnaEventHandler.RecordCardChose(handCards[0]);
        }
        
        Inventory.instance.Add(handCards[0]);
        handCards.Remove(handCards[0]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
        
    }

    public void SelectSecondCard() {
        if (deltaDnaEventHandler) {
            deltaDnaEventHandler.RecordCardChose(handCards[1]);
        }
        
        Inventory.instance.Add(handCards[1]);
        handCards.Remove(handCards[1]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
        
    } 

    public void SelectThirdCard() {
        if (deltaDnaEventHandler) {
            deltaDnaEventHandler.RecordCardChose(handCards[2]);
        }
        
        Inventory.instance.Add(handCards[2]);
        handCards.Remove(handCards[2]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }

    private void TurnOrange(Button button) {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color32(255, 210, 2, 200);
        colors.highlightedColor = new Color32(255, 210, 2, 255);
        colors.pressedColor = new Color32(241, 162, 22, 255);
        colors.selectedColor = new Color32(241, 162, 22, 255);
        button.colors = colors;
    }
     
     
    private void TurnBlue(Button button) {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color32(33, 101, 255, 200);
        colors.highlightedColor = new Color32(33, 101, 255, 230);
        colors.pressedColor = new Color32(18, 49, 246, 200);
        colors.selectedColor = new Color32(18, 49, 246, 200);
        button.colors = colors;
    }

    private void TurnWhite(Button button) {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(245, 245, 245, 255);
        colors.pressedColor = new Color32(200, 200, 200, 255);
        colors.selectedColor = new Color32(200, 200, 200, 255);
        button.colors = colors;
    }

    private void SetCardColor(int rank, int index) {
        if (rank == 3) {
            TurnOrange(buttons[index]);
        } else if (rank == 2) {
            TurnBlue(buttons[index]);
        } else if (rank == 1) {
            TurnWhite(buttons[index]);
        }
    }

}
