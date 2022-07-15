using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class CardInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject wrapper;
    bool setFirstCard;
    bool setSecondCard;
    CardPanel cardPanel;
    
    public bool ActiveCardUI = true;
    // [SerializeField] GameObject goldPrefab;
    // [SerializeField] GameObject silverPrefab;
    // [SerializeField] GameObject bronzePrefab;

    
    [SerializeField] List<InputActionReference> inputActionReference;

    void start() {
        cardPanel = FindObjectOfType<CardPanel>();
    }
    void Update() {
        CheckCardExisting();
    }
    void CheckCardExisting() {
        if (!setFirstCard && Inventory.instance.cards.ContainsKey(0)) {
            DrawNewCardUI(0);
            setFirstCard = true;
        } else if (!Inventory.instance.cards.ContainsKey(0) && transform.GetChild(0).GetChild(0).childCount >= 1 && transform.GetChild(0).GetChild(0).GetChild(0).gameObject){
            CloseCardUI(0);
            setFirstCard = false;
        }
        if (!setSecondCard && Inventory.instance.cards.ContainsKey(1)) {
            DrawNewCardUI(1);
            setSecondCard = true;
        } else if (!Inventory.instance.cards.ContainsKey(1) && transform.GetChild(0).GetChild(0).childCount >= 2 && transform.GetChild(0).GetChild(0).GetChild(1).gameObject){
            CloseCardUI(1);
            setSecondCard = false;
        }
        if ((setFirstCard || setSecondCard) && ActiveCardUI) {
            OpenCardUI();
        } else {
            CloseCardUI();
        }
    }
    void DrawNewCardUI(int i) {
        CreateCardUI(Inventory.instance.cards[i], i);
    }
    void UpdateKeyBinding(int i) {
        GameObject gameObject = transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetChild(0).gameObject;
        if (inputActionReference[i].action != null && Inventory.instance.cards.ContainsKey(i)){
            TextMeshProUGUI textMeshProUGUI = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            var actionName = inputActionReference[i].action.name;
            textMeshProUGUI.text = InputManager.GetBindingName(actionName, 0);
        }
    }
    // void ActivateCard() {
    //     Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    //     image.color = new Color32();
    // }
    // void CreateCardUI(Card card, int i)
    // {
    //     Transform parentTransform = transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).GetChild(1);
    //     Debug.Log(parentTransform);
    //     transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
    //     GameObject cardObject = null;
    //     if (card.rank == 3) {
    //         cardObject = Instantiate(goldPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
    //     } else if (card.rank == 2) {
    //         cardObject = Instantiate(silverPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
    //     } else if (card.rank == 1) {
    //         cardObject = Instantiate(bronzePrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
    //     } 
    //     // cardObject.name = "Card " + index;
    //     // Component[] textMeshProUGUI;
    //     // textMeshProUGUI = cardObject.transform.GetChild(0).GetComponents(typeof(TextMeshProUGUI));
    //     TextMeshProUGUI timeMeshProUGUI = cardObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    //     // Debug.Log(cardObject);
    //     TextMeshProUGUI nameMeshProUGUI = cardObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
    //     TextMeshProUGUI detailMeshProUGUI = cardObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
    //     nameMeshProUGUI.text = card.cardName;
    //     timeMeshProUGUI.text = card.time + "s";
    //     detailMeshProUGUI.text = card.cardDetail;
    //     string iconImageRoute = card.name;
    //     Sprite cardImage = Resources.Load<Sprite>(iconImageRoute);
    //     cardObject.transform.GetChild(0).GetComponent<Image>().sprite = cardImage;
    //     string signImageRoute = card.cardType;
    //     Sprite cardSign = Resources.Load<Sprite>("CardType/" + signImageRoute);
    //     cardObject.transform.GetChild(4).GetChild(1).GetComponent<Image>().sprite = cardSign;
    // }
    void CreateCardUI(Card card, int i)
    {
        GameObject gameObject = transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject;
        gameObject.SetActive(true);
        TextMeshProUGUI textMeshProUGUI = gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        // TextMeshProUGUI timerMeshProUGUI = gameObject.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.text = card.cardName + "  " + card.time + "s";
        // timerMeshProUGUI.text = card.time + "s";
        string imageRoute = card.name;
        Sprite cardImage = Resources.Load<Sprite>(imageRoute);
        gameObject.transform.GetChild(1).GetComponent<Image>().sprite = cardImage;
    }
    void CloseCardUI(int i) {
        transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
    }
    void DestroyCardUI(int i) {
        Destroy(transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
    }
    public void OpenCardUI() {
        wrapper.SetActive(true);
        UpdateKeyBinding(0);
        UpdateKeyBinding(1);
    }
    public void CloseCardUI() {
        wrapper.SetActive(false);
    }
}
