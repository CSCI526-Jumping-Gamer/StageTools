using System;
using System.Collections;
using UnityEngine;
using TMPro;
public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimeControl instance;
    public TextMeshProUGUI timeCount;
    public TextMeshProUGUI timeSpentOnStage;

    [SerializeField] GameObject wrapper;

    private TimeSpan timeSpan;
    private float timeElapsed;
    private bool isTimerOn;

    private void Awake()
    {
        wrapper.SetActive(true);
        instance = this;
    }

    private void Start()
    {
        timeCount.text = "Time: 00:00.00";
        timeSpentOnStage.text = "00 sec";
        isTimerOn = false;
        this.TimerBegin();
    }

    public void TimerBegin()
    {
        isTimerOn = true;
        timeElapsed = 0f;

        StartCoroutine(UpdateTimer());

    }

    public float getTimeElapsed()
    {
        return timeElapsed;
    }

    public void showTimerOnEndCanvas()
    {
        timeSpentOnStage.text = timeSpan.TotalSeconds + " sec";
    }

    public void TimerEnd()
    {
        isTimerOn = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (isTimerOn)
        {
            timeElapsed += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(timeElapsed);
            string timerStr = "Time: " + timeSpan.ToString("mm':'ss'.'ff");
            timeCount.text = timerStr;
            yield return null;
        }
    }




}
