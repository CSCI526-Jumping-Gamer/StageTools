using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColor : MonoBehaviour
{
    // Start is called before the first frame update
    // TimeControl timeControl;
    [SerializeField] GameObject[] stars;
    [SerializeField] int threeStarTime = 60;
    [SerializeField] int twoStarTime = 90;
    
    void Awake() {
        
    }

    public void setStarColor() {
        float time = TimeControl.timerObj.getTimeElapsed();
        
        if (time <= threeStarTime) {
            stars[0].SetActive(true);
        } else if (time <= twoStarTime) {
            stars[1].SetActive(true);
        } else {
            stars[2].SetActive(true);
        }
    }
}
