using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarColor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] stars;
    public void setStarColor() {
        
        int time = Random.Range(30, 121);
        if (time <= 60) {
            stars[0].SetActive(true);
        } else if (time <= 90){
            stars[1].SetActive(true);
        } else {
            stars[2].SetActive(true);
        }
    }
}
