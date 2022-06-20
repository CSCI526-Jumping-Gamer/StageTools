using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimeControl timerObj;
    public TextMeshProUGUI timeCount;
    public TextMeshProUGUI timeSpendOnStage;

    private TimeSpan timeSpan;
    private float timeElapsed;
    private bool isTimerOn;

    private void Awake() {
        timerObj = this;
    }

    private void Start() {
        timeCount.text = "Time: 00:00.00";
        timeSpendOnStage.text = "00 sec";
        isTimerOn = false;
        this.TimerBegin();
    }

    public void TimerBegin() {
        isTimerOn = true;
        timeElapsed = 0f;

        StartCoroutine(UpdateTimer());

    }

    public void showTimerOnEndCanvas() {
        timeSpendOnStage.text = timeSpan.ToString("ss'.'ff") + " sec";
    }

    public void TimerEnd() {
        isTimerOn = false;
    }

    private IEnumerator UpdateTimer() {
        while (isTimerOn) {
            timeElapsed += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(timeElapsed);
            string timerStr = "Time: " + timeSpan.ToString("mm':'ss'.'ff");
            timeCount.text = timerStr;
            yield return null;
        }
    }




}
