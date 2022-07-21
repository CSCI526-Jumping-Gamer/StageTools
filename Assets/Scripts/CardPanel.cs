using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
public class CardPanel : MonoBehaviour
{
    List<Card> oneStarCards; // 25%
    List<Card> twoStarCards; // 50%
    List<Card> threeStarCards; // 25%
    List<Card> handCards;
    int cardsLength = 3;
    CardPool cardPool;
    CardInventoryUI cardInventoryUI;
    DeltaDnaEventHandler deltaDnaEventHandler;
    [SerializeField] List<int> cardScores;
    [SerializeField] public bool cardEnabled = true;
    [SerializeField] GameObject wrapper;
    [SerializeField] GameObject goldPrefab;
    [SerializeField] GameObject silverPrefab;
    [SerializeField] GameObject bronzePrefab;
    [SerializeField] TimeControl timeControl;

    private void Awake()
    {
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
        cardPool = FindObjectOfType<CardPool>();
        cardInventoryUI = FindObjectOfType<CardInventoryUI>();
        timeControl.isCardEnabled = cardEnabled;
        // Debug.Log(cardPool.oneStarCards.Count);
    }

    void Start()
    {
        if (cardEnabled)
        {
            PlayerController.instance.DisablePlayerInput();
            Invoke("StartCardPanel", 0.2f);
        }
    }

    void InitializeOneStarCards()
    {
        oneStarCards = new List<Card>(cardPool.oneStarCards);
    }

    void InitializeTwoStarCards()
    {
        twoStarCards = new List<Card>(cardPool.twoStarCards);
    }

    void InitializeThreeStarCards()
    {
        threeStarCards = new List<Card>(cardPool.threeStarCards);
    }

    void InitializeCardPool()
    {
        if (oneStarCards == null || oneStarCards.Count == 0)
        {
            InitializeOneStarCards();
        }

        if (twoStarCards == null || twoStarCards.Count == 0)
        {
            InitializeTwoStarCards();
        }

        if (threeStarCards == null || threeStarCards.Count == 0)
        {
            InitializeThreeStarCards();
        }
    }

    List<int> CalculateCardScores()
    {
        List<int> result = new List<int>();
        GetFirstCardScore(result);
        GetRemainingCardScores(result);
        return result;
    }

    public void GetFirstCardScore(List<int> result)
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int prevSceneIndex = currSceneIndex - 1;
        
        
        if (PlayerPrefs.GetInt("Level " + currSceneIndex) != 0) {
            Scoreboard.score = PlayerPrefs.GetInt("Level " + currSceneIndex);
        } else if (PlayerPrefs.GetInt("Level " + prevSceneIndex) != 0) {
            Scoreboard.score = PlayerPrefs.GetInt("Level " + prevSceneIndex);
        } else {
            Scoreboard.score = 1;
        }
        
            
       


        if (Scoreboard.score == 3)
        {
            if (threeStarCards.Count > 0)
            {
                result.Add(100);
            }
            // Debug.Log("3 star card");
        }
        else if (Scoreboard.score == 2)
        {
            if (twoStarCards.Count > 0)
            {
                result.Add(50);
            }
            // Debug.Log("2 star card");
        }
        else
        {
            if (oneStarCards.Count > 0)
            {
                result.Add(1);
            }
            // Debug.Log("1 star card");
        }
    }

    public void GetRemainingCardScores(List<int> result)
    {
        int count = result.Count;

        for (int i = 0; i < cardsLength - count; i++)
        {
            if (oneStarCards.Count == 0 && twoStarCards.Count == 0 && threeStarCards.Count == 0)
            {
                return;
            }
            else if (oneStarCards.Count == 0 && twoStarCards.Count == 0)
            {
                result.Add(100);
            }
            else if (oneStarCards.Count == 0 && threeStarCards.Count == 0)
            {
                result.Add(50);
            }
            else if (twoStarCards.Count == 0 && threeStarCards.Count == 0)
            {
                result.Add(1);
            }
            else if (oneStarCards.Count == 0)
            {
                result.Add(Random.Range(26, 101));
            }
            else if (twoStarCards.Count == 0)
            {
                int r1 = Random.Range(1, 26);
                int r2 = Random.Range(75, 101);
                int decision = Random.Range(0, 2);

                if (decision == 0)
                {
                    result.Add(r1);
                }
                else
                {
                    result.Add(r2);
                }
            }
            else
            {
                result.Add(Random.Range(1, 76));
            }
        }
    }

    public void StartCardPanel()
    {
        wrapper.SetActive(true);
        transform.GetChild(0).GetChild(0).DetachChildren();
        handCards = new List<Card>();
        InitializeCardPool();
        cardScores = CalculateCardScores();

        for (int i = 0; i < cardsLength; i++)
        {
            DrawCard(i);
        }

        Time.timeScale = 0f;
    }

    void DrawCard(int index)
    {
        Card currCard = null;
        if (cardScores[index] <= 25)
        {
            // 1 star
            if (oneStarCards.Count == 0)
            {
                return;
            }

            currCard = oneStarCards[Random.Range(0, oneStarCards.Count)];
            oneStarCards.Remove(currCard);
        }
        else if (cardScores[index] <= 75)
        {
            // 2 star
            if (twoStarCards.Count == 0)
            {
                return;
            }

            currCard = twoStarCards[Random.Range(0, twoStarCards.Count)];
            twoStarCards.Remove(currCard);
        }
        else
        {
            // 3 star
            if (threeStarCards.Count == 0)
            {
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

    void CreateCard(Card card, int index)
    {
        Transform parentTransform = transform.GetChild(0).GetChild(0);
        GameObject cardObject = null;
        if (card.rank == 3)
        {
            cardObject = Instantiate(goldPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
        }
        else if (card.rank == 2)
        {
            cardObject = Instantiate(silverPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
        }
        else if (card.rank == 1)
        {
            cardObject = Instantiate(bronzePrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
        }
        // cardObject.name = "Card " + index;
        // Component[] textMeshProUGUI;
        // textMeshProUGUI = cardObject.transform.GetChild(0).GetComponents(typeof(TextMeshProUGUI));
        // Debug.Log(cardObject);
        TextMeshProUGUI timeMeshProUGUI = cardObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nameMeshProUGUI = cardObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI detailMeshProUGUI = cardObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        nameMeshProUGUI.text = card.cardName;
        timeMeshProUGUI.text = card.time + "s";
        detailMeshProUGUI.text = card.cardDetail;
        string iconImageRoute = card.name;
        Sprite cardImage = Resources.Load<Sprite>(iconImageRoute);
        cardObject.transform.GetChild(0).GetComponent<Image>().sprite = cardImage;
        string signImageRoute = card.cardType;
        Sprite cardSign = Resources.Load<Sprite>("CardType/" + signImageRoute);
        cardObject.transform.GetChild(4).GetChild(1).GetComponent<Image>().sprite = cardSign;

        Button button = cardObject.GetComponent<Button>();

        if (index == 0)
        {
            button.onClick.AddListener(SelectFirstCard);
        }
        else if (index == 1)
        {
            button.onClick.AddListener(SelectSecondCard);
        }
        else
        {
            button.onClick.AddListener(SelectThirdCard);
        }

        SetCardColor(card.rank, button);
        // gameObject.transform.SetParent();
    }

    void RemoveCardFromPool(Card card)
    {
        if (card.rank == 1)
        {
            oneStarCards.Remove(card);
        }
        else if (card.rank == 2)
        {
            twoStarCards.Remove(card);
        }
        else
        {
            threeStarCards.Remove(card);
        }
    }

    void AddCardBacktoPool()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            int rank = handCards[i].rank;

            if (rank == 1)
            {
                oneStarCards.Add(handCards[i]);
            }
            else if (rank == 2)
            {
                twoStarCards.Add(handCards[i]);
            }
            else
            {
                threeStarCards.Add(handCards[i]);
            }
        }
    }

    public void SelectFirstCard()
    {
        if (deltaDnaEventHandler)
        {
            deltaDnaEventHandler.RecordCardChose(handCards[0]);
        }

        Inventory.instance.Add(handCards[0]);
        handCards.Remove(handCards[0]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
        TimeControl.instance.TimerBegin();
        cardInventoryUI.OpenCardUI();
    }

    public void SelectSecondCard()
    {
        if (deltaDnaEventHandler)
        {
            deltaDnaEventHandler.RecordCardChose(handCards[1]);
        }

        Inventory.instance.Add(handCards[1]);
        handCards.Remove(handCards[1]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
        TimeControl.instance.TimerBegin();
        cardInventoryUI.OpenCardUI();
    }

    public void SelectThirdCard()
    {
        if (deltaDnaEventHandler)
        {
            deltaDnaEventHandler.RecordCardChose(handCards[2]);
        }

        Inventory.instance.Add(handCards[2]);
        handCards.Remove(handCards[2]);
        AddCardBacktoPool();
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
        TimeControl.instance.TimerBegin();
        cardInventoryUI.OpenCardUI();
    }
    private void TurnOrange(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color32(255, 210, 2, 200);
        colors.highlightedColor = new Color32(226, 186, 0, 200);
        colors.pressedColor = new Color32(195, 160, 0, 200);
        colors.selectedColor = new Color32(195, 160, 0, 200);
        button.colors = colors;
    }
    private void TurnBlue(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = new Color32(33, 101, 255, 200);
        colors.highlightedColor = new Color32(20, 83, 226, 200);
        colors.pressedColor = new Color32(18, 49, 246, 200);
        colors.selectedColor = new Color32(18, 49, 246, 200);
        button.colors = colors;
    }

    private void TurnWhite(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(221, 221, 221, 255);
        colors.pressedColor = new Color32(200, 200, 200, 255);
        colors.selectedColor = new Color32(200, 200, 200, 255);
        button.colors = colors;
    }

    private void SetCardColor(int rank, Button button)
    {
        if (rank == 3)
        {
            TurnOrange(button);
        }
        else if (rank == 2)
        {
            TurnBlue(button);
        }
        else if (rank == 1)
        {
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