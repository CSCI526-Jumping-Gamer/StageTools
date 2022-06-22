using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class CardTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerCard playerCard;
    public Slider cardTimerSlider;
    public Image cardTimerBackground;
    public Image cardTimerFill;
    public TextMeshProUGUI cardTimerText;
    public TextMeshProUGUI cardNameText;
    public string cardName;
    public float cardTime;
    public float cardTimerValue;

    void Start()
    {
        // cardTimerSlider = GetComponent<Slider>();
        // cardTimerText = GetComponent<TextMeshProUGUI>();
        UpdateCardState();
        if (playerCard.GetCardState() == 1) {
            CardTimerEnabled();
        } else {
            CardTimerDisabled();
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateCardState();
        UpdateTimer();
        DisplayTime(cardTimerValue, cardName);
    }
    void UpdateCardState() {
        // Update cardState
        // if (playerCard.GetCardNumber() != 0) {
        //     playerCard.cardState = 1;
        // }
        // Update cardTime
        cardTime = playerCard.GetCardTime();
        // Update cardName
        cardName = playerCard.GetCardName();
        if (playerCard.GetCardState() == 1) {
            cardTimerValue = cardTime;
            cardTimerSlider.maxValue = cardTime;
        }
    }
    void CardTimerEnabled() {   
        cardTimerBackground.enabled = true;
        cardTimerFill.enabled = true;
        cardTimerText.enabled = true;
        cardNameText.enabled = true;
        cardTimerSlider.maxValue = cardTime;
        cardTimerSlider.value = cardTime;
    }

    void CardTimerDisabled() {
        cardTimerBackground.enabled = false;
        cardTimerFill.enabled = false;
        cardTimerText.enabled = false;
        cardNameText.enabled = false;
    }
    void UpdateTimer()
    {
        if (playerCard.GetCardState() == 2) {
            cardTimerValue -= Time.deltaTime;
            if (cardTimerValue <= 0) {
                CardTimerDisabled();
                playerCard.EndCard();
            }
        }
    }
    // public void StartCardTimer() {
        
    // }
    void DisplayTime(float t, string s) {
        cardNameText.text = s;
        cardTimerSlider.value = t;
        string seconds = (t).ToString("00");
        string milliseconds = ((int) (t * 100f) % 100).ToString("00");
        cardTimerText.text = seconds + ":" + milliseconds;
    }
}
