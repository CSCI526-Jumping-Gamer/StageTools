using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColor : MonoBehaviour
{
    // Start is called before the first frame update
    // TimeControl timeControl;
    public GameObject[] stars;
    public void setStarColor()
    {

        float time = TimeControl.timerObj.getTimeElapsed();
        Debug.Log(time);
        if (time <= 60)
        {
            stars[0].SetActive(true);
        }
        else if (time <= 90)
        {
            stars[1].SetActive(true);
        }
        else
        {
            stars[2].SetActive(true);
        }
    }
}
