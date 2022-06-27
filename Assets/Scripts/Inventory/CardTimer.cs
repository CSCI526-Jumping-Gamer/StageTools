using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class CardTimer : MonoBehaviour
{
    bool isActivated = false;
    Card card;

    [SerializeField] GameObject wrapper;

    public Slider slider;
    public Image background;
    public Image fill;
    public TextMeshProUGUI remainingTimeText;
    public TextMeshProUGUI cardNameText;
    public string cardName = "empty";
    public float remainingTime = 0f;
    
    public void Activate(Card card) {
        this.card = card;
        SetupCardTimer();
        wrapper.SetActive(true);
        isActivated = true;
    }
    public void Deactivate() {
        wrapper.SetActive(false);
        isActivated = false;
    }

    void Update() {
        if (isActivated) {
            if (remainingTime > 0f) {
                remainingTime -= Time.deltaTime;
                DisplayTime();
            } else {
                isActivated = false;
                card.Deactivate();
                wrapper.SetActive(false);
                Inventory.instance.Remove(card);
                PlayerController.instance.isUsingCard = false;
            }
        }
    }

    void SetupCardTimer() {
        remainingTime = card.time;
        cardName = card.cardName;
        slider.maxValue = card.time;;
        slider.value = card.time;;
    }
    
    void DisplayTime() {
        cardNameText.text = cardName;
        slider.value = remainingTime;
        string seconds = ((int)remainingTime).ToString();
        string milliseconds = ((int) (remainingTime * 100f) % 100).ToString("00");
        remainingTimeText.text = seconds + ":" + milliseconds;
    }
}
