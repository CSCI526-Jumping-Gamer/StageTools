using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInventoryUI : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int cardsUILength;
    [SerializeField] GameObject wrapper;
    
    void Update() {
        if (cardsUILength < Inventory.instance.cards.Count) {
            cardsUILength = Inventory.instance.cards.Count;
            if (cardsUILength != 0) {
                OpenCardUI();
            }
            if (cardsUILength <= 3) {
                DrawNewCardUI();
            }
        } else if (cardsUILength > Inventory.instance.cards.Count) {
            cardsUILength = Inventory.instance.cards.Count;
            DestroyFirstCardUI();
            if (cardsUILength == 0) {
                CloseCardUI();
            }
        }
    }
    void DrawNewCardUI() {
        CreateCardUI(Inventory.instance.cards[cardsUILength - 1], cardsUILength - 1);
    }
    // void ActivateCard() {
    //     Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    //     image.color = new Color32();
    // }
    void CreateCardUI(Card card, int index)
    {
        Transform parentTransform = transform.GetChild(0).GetChild(0);
        GameObject gameObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
        gameObject.name = "CardUI " + index;
        string imageRoute = card.name;
        Sprite cardImage = Resources.Load<Sprite>(imageRoute);
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = cardImage;
        // Button button = gameObject.GetComponent<Button>();

        // if (index == 0)
        // {
        //     button.onClick.AddListener(SelectFirstCard);
        // }
        // else if (index == 1)
        // {
        //     button.onClick.AddListener(SelectSecondCard);
        // }
        // else
        // {
        //     button.onClick.AddListener(SelectThirdCard);
        // }
    }
    void DestroyFirstCardUI() {
        Destroy(transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
    }
    public void OpenCardUI() {
        wrapper.SetActive(true);
    }
    public void CloseCardUI() {
        wrapper.SetActive(false);
    }
}
