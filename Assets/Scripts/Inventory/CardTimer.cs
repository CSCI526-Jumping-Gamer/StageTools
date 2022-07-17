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
    int cardKey;

    public void Activate(Card card, int i)
    {
        this.card = card;
        SetupCardTimer();
        // Debug.Log(wrapper);
        wrapper.SetActive(true);
        isActivated = true;
        cardKey = i;
    }
    public void Deactivate()
    {
        card.Deactivate();
        wrapper.SetActive(false);
        // Inventory.instance.Remove(cardKey);
        PlayerController.instance.isUsingCard = false;
        isActivated = false;
    }

    void Update()
    {
        if (isActivated)
        {
            if (remainingTime > 0f)
            {
                remainingTime -= Time.deltaTime;
                DisplayTime();
            }
            else
            {
                Deactivate();
            }
        }
    }

    void SetupCardTimer()
    {
        remainingTime = card.time;
        cardName = card.cardName;
        slider.maxValue = card.time; ;
        slider.value = card.time; ;
    }

    void DisplayTime()
    {
        cardNameText.text = cardName;
        slider.value = remainingTime;
        string seconds = ((int)remainingTime).ToString();
        string milliseconds = ((int)(remainingTime * 100f) % 100).ToString("00");
        remainingTimeText.text = seconds + ":" + milliseconds;
    }
}
