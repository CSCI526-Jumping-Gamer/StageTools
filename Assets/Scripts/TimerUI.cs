using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] float timeGold = 60f;
    [SerializeField] float timeSilver = 120f;
    // [SerializeField] float timeBronze = 300f;
    public static float timerValue;
    public static bool TimeUp = false;

    public static int rank = 0;

    public bool isPassedLevel;
    public TextMeshProUGUI timerText;



    private void Awake() {
        timerText = GetComponent<TextMeshProUGUI>();
        isPassedLevel = false;
    }
    void Update()
    {
        UpdateTimer();
        DisplayTime(timerValue);
        UpdateTimerColor();
    }

    // Update is called once per frame
    void UpdateTimer()
    {
        if (rank == 0) {
            timerValue = 0;
        }
        timerValue += Time.deltaTime;
        
        if (isPassedLevel) {
            timerValue = 0;
            rank = 0;
        }
        if (timerValue <= timeGold) {
            rank = 3;
        } else if (timeGold < timerValue && timerValue <= timeSilver) {
            rank = 2;
        } else {
            rank = 1;
        }
    }
    void DisplayTime(float t) {
        
        string minutes = ((int) t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string milliseconds = ((int) (t * 100f) % 100).ToString("00");
        timerText.text = minutes + ":" + seconds + ":" + milliseconds;
    }
    void UpdateTimerColor() {
        switch (rank) {
            case 3:
                timerText.color = new Color32(255, 215, 0, 255);
                break;
            case 2:
                timerText.color = new Color32(192, 192, 192, 255);
                break;
            case 1:
                timerText.color = new Color32(205, 127, 50, 255);
                break;
        }
    }
}
