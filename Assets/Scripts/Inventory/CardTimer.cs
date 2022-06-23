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

    public Slider slider;
    public Image background;
    public Image fill;
    public TextMeshProUGUI remainingTimeText;
    public TextMeshProUGUI cardNameText;
    public string cardName;
    public float remainingTime;

    void Start() {
        DisableCardTimer();
    } 

    public void Activate(Card card) {
        this.card = card;
        EnbableCardTimer();
        DisplayTime(remainingTime, cardName);
        SetIsActivated(true);
    }

    void Update() {
        if (isActivated) {
            if (remainingTime > 0f) {
                UpdateTimer();
                DisplayTime(remainingTime, cardName);
            } else {
                isActivated = false;
                card.Deactivate();
                DisableCardTimer();
                Inventory.instance.Remove(card);
                PlayerController.instance.SetIsUsingCard(false);
            }
        }
    }
    
    public void EnbableCardTimer() {   
        remainingTime = card.time;
        cardName = card.cardName;
        background.enabled = true;
        fill.enabled = true;
        remainingTimeText.enabled = true;
        cardNameText.enabled = true;
        slider.maxValue = card.time;;
        slider.value = card.time;;
    }

    void DisableCardTimer() {
        background.enabled = false;
        fill.enabled = false;
        remainingTimeText.enabled = false;
        cardNameText.enabled = false;
    }
    void UpdateTimer() {
        remainingTime -= Time.deltaTime;
    }

    void DisplayTime(float t, string s) {
        cardNameText.text = s;
        slider.value = t;
        string seconds = ((int)t).ToString();
        string milliseconds = ((int) (t * 100f) % 100).ToString("00");
        remainingTimeText.text = seconds + ":" + milliseconds;
    }

    public void SetIsActivated(bool isActivated) {
        this.isActivated = isActivated;
    }
}
