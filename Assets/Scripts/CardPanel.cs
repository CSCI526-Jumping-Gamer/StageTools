using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class CardPanel : MonoBehaviour
{
    List<Card> oneStarCards; // 25%
    List<Card> twoStarCards; // 50%
    List<Card> threeStarCards; // 25%
    List<Card> handCards;
    int cardsLength = 3;
    CardPool cardPool;
    int bias = 0;
    DeltaDnaEventHandler deltaDnaEventHandler;
    [SerializeField] List<int> cardScores;
    [SerializeField] bool cardEnabled = true;
    [SerializeField] GameObject wrapper;
    [SerializeField] GameObject prefab;
    
    
    private void Awake() {
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
        cardPool = FindObjectOfType<CardPool>();
        Debug.Log(cardPool.oneStarCards.Count);
    }

    void Start() {
        if (cardEnabled) {
            InitializeCardPool();
            cardScores = calculateCardScores();
            PlayerController.instance.DisablePlayerInput();
            Invoke("StartCardPanel", 0.2f);
        }
    }

    void InitializeCardPool() {
        InitializeOneStarCards();
        InitializeTwoStarCards();
        InitializeThreeStarCards();
    }

    void InitializeOneStarCards() {
        oneStarCards = new List<Card>(cardPool.oneStarCards);

        // oneStarCards = new List<Card> {
        //     ScriptableObject.CreateInstance<SpeedUp>(), 
        //     ScriptableObject.CreateInstance<HighJump>(), 
        //     ScriptableObject.CreateInstance<SingleUseShield>(),
        //     ScriptableObject.CreateInstance<LightWeight>(),
        //     ScriptableObject.CreateInstance<RopeClimber>() }; // 25%
    }

    void InitializeTwoStarCards() {
        twoStarCards = new List<Card>(cardPool.twoStarCards);
        
        // twoStarCards = new List<Card> {
        //     ScriptableObject.CreateInstance<SlingshotHelper>(),
        //     ScriptableObject.CreateInstance<DoubleJump>(),
        //     ScriptableObject.CreateInstance<Flash>(),
        //     ScriptableObject.CreateInstance<LunarGravity>(),
        //     ScriptableObject.CreateInstance<ThreeTimesShield>() }; // 50%
    }

    void InitializeThreeStarCards() {
        threeStarCards = new List<Card>(cardPool.threeStarCards);

        // threeStarCards = new List<Card> {
        //     ScriptableObject.CreateInstance<ZeroGravity>(),
        //     ScriptableObject.CreateInstance<Invincible>(),
        //     ScriptableObject.CreateInstance<TripleJump>() };// 25%
    }

    void CheckCardPoolValidility() {
        if (oneStarCards.Count == 0) {
            InitializeOneStarCards();
        }

        if (twoStarCards.Count == 0) {
            InitializeTwoStarCards();
        }

        if (threeStarCards.Count == 0) {
            InitializeThreeStarCards();
        }
    }

    bool isCardPoolValid() {
        if (oneStarCards.Count == 0) {
            return false;
        }

        if (twoStarCards.Count == 0) {
            return false;
        }

        if (threeStarCards.Count == 0) {
            return false;
        }

        return true;
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

        // return new List<int> { 
        //     1, 1, 1 };    
    }

    public void StartCardPanel() {
        wrapper.SetActive(true);
        transform.GetChild(0).GetChild(0).DetachChildren();
        handCards = new List<Card>();
        CheckCardPoolValidility();

        for (int i = 0; i < cardsLength; i++) {
            DrawCard(i);
        }
    
        Time.timeScale = 0f;
    }

    void DrawCard(int index) {
        Card currCard = null;
        if (cardScores[index] <= 25) {
            // 1 star
            if (oneStarCards.Count == 0) {
                return;
            }
           
            currCard = oneStarCards[Random.Range(0, oneStarCards.Count)];
            oneStarCards.Remove(currCard);
        } else if (cardScores[index] <= 75) {
            // 2 star
            if (twoStarCards.Count == 0) {
                return;
            }

            currCard = twoStarCards[Random.Range(0, twoStarCards.Count)];
            twoStarCards.Remove(currCard);
        } else { 
            // 3 star
            if (threeStarCards.Count == 0) {
                return;
            }

            currCard = threeStarCards[Random.Range(0, threeStarCards.Count)];
            threeStarCards.Remove(currCard);
        }

        CreateCard(currCard, index);
        // cardText[index].text = currCard.cardName; 
        // SetCardColor(currCard.rank, index);
        // Debug.Log("Card Rank: " + currCard.rank);
        handCards.Add(currCard);
    }

    void CreateCard(Card card, int index) {
        Transform parentTransform = transform.GetChild(0).GetChild(0);
        GameObject gameObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
        gameObject.name = "Card " + index;
        TextMeshProUGUI textMeshProUGUI = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = card.cardName;
        Button button = gameObject.GetComponent<Button>();

        if (index == 0) {
            button.onClick.AddListener(SelectFirstCard);
        } else if (index == 1) {
            button.onClick.AddListener(SelectSecondCard);
        } else {
            button.onClick.AddListener(SelectThirdCard);
        }

        SetCardColor(card.rank, button);
        // gameObject.transform.SetParent();
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
        colors.highlightedColor = new Color32(226, 186, 0, 200);
        colors.pressedColor = new Color32(195, 160, 0, 200);
        colors.selectedColor = new Color32(195, 160, 0, 200);
        button.colors = colors;
    }
    private void TurnBlue(Button button) {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color32(33, 101, 255, 200);
        colors.highlightedColor = new Color32(20, 83, 226, 200);
        colors.pressedColor = new Color32(18, 49, 246, 200);
        colors.selectedColor = new Color32(18, 49, 246, 200);
        button.colors = colors;
    }

    private void TurnWhite(Button button) {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(221, 221, 221, 255);
        colors.pressedColor = new Color32(200, 200, 200, 255);
        colors.selectedColor = new Color32(200, 200, 200, 255);
        button.colors = colors;
    }

    private void SetCardColor(int rank, Button button) {
        if (rank == 3) {
            TurnOrange(button);
        } else if (rank == 2) {
            TurnBlue(button);
        } else if (rank == 1) {
            TurnWhite(button);
        }
    }
}

// GameObject gameObject = new GameObject("Card " + index);
// gameObject.AddComponent<RectTransform>();
// gameObject.AddComponent<Image>();
// gameObject.AddComponent<Button>();
// RectTransform rt = gameObject.GetComponent<RectTransform>();
// rt.sizeDelta = new Vector2(200, 300);
// rt.localScale = new Vector3(1, 1, 1);
// gameObject.transform.localScale = new Vector3(1, 1, 1);
// gameObject.transform.SetParent(transform.GetChild(0).GetChild(0));