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
    
    public bool ActiveCardUI = true;

    
    [SerializeField] List<InputActionReference> inputActionReference;

    
    void Update() {
        CheckCardExisting();
        UpdateKeyBinding(0);
        UpdateKeyBinding(1);
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
        GameObject gameObject = transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject;
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
    void CreateCardUI(Card card, int i)
    {
        GameObject gameObject = transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject;
        gameObject.SetActive(true);
        string imageRoute = card.name;
        Sprite cardImage = Resources.Load<Sprite>(imageRoute);
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = cardImage;
    }
    void CloseCardUI(int i) {
        transform.GetChild(0).GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
    }
    void DestroyCardUI(int i) {
        Destroy(transform.GetChild(0).GetChild(0).GetChild(i).gameObject);
    }
    public void OpenCardUI() {
        wrapper.SetActive(true);
    }
    public void CloseCardUI() {
        wrapper.SetActive(false);
    }
}
