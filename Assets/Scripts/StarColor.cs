using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColor : MonoBehaviour
{
    Scoreboard scoreboard;

    [SerializeField] GameObject[] stars;
    [SerializeField] int threeStarTime = 60;
    [SerializeField] int twoStarTime = 90;
    
    void Awake() {
        scoreboard = GetComponent<Scoreboard>();
    }

    public void setStarColor() {
        float time = TimeControl.instance.getTimeElapsed();
        
        if (time <= threeStarTime) {
            stars[0].SetActive(true);
            Scoreboard.score = 3;
        } else if (time <= twoStarTime) {
            stars[1].SetActive(true);
            Scoreboard.score = 2;
        } else {
            stars[2].SetActive(true);
            Scoreboard.score = 1;
        }
    }
}
