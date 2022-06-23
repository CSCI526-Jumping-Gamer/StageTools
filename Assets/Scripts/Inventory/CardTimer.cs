using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class CardTimer : MonoBehaviour
{
    bool isActivated;
    Card card;

    public Slider slider;
    public Image background;
    public Image fill;
    public TextMeshProUGUI remainingTimeText;
    public TextMeshProUGUI cardNameText;
    public string cardName;
    public float remainingTime;

    void Start() {
        // Inventory.instance.Add(ScriptableObject.CreateInstance<DoubleJump>());
        // Inventory.instance.Add(ScriptableObject.CreateInstance<SpeedUp>());
        Inventory.instance.Add(ScriptableObject.CreateInstance<SlingshotHelper>());
        card = Inventory.instance.GetFirstCard();
        remainingTime = card.time;
        cardName = card.cardName;
        isActivated = false;
        EnbableCardTimer();
        DisplayTime(remainingTime, cardName);
    } 

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    public void Activate() {
        SetIsActivated(true);
        card.Activate();
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
            }
        }
    }
    
    public void EnbableCardTimer() {   
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
