using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (time <= threeStarTime) {
            stars[0].SetActive(true);
            SetLevelScore("Level " + currentScene, 3);
            Scoreboard.score = 3;
        } else if (time <= twoStarTime) {
            stars[1].SetActive(true);
            SetLevelScore("Level " + currentScene, 2);
            Scoreboard.score = 2;
            
        } else {
            stars[2].SetActive(true);
            SetLevelScore("Level " + currentScene, 1);
            Scoreboard.score = 1;
        }
    }

    private void SetLevelScore(string currentLevel, int rank) {
        if (!PlayerPrefs.HasKey(currentLevel)) {
            PlayerPrefs.SetInt(currentLevel, rank);
            return;
        }

        // update level rank if player gets a higher rank
        if (rank > PlayerPrefs.GetInt(currentLevel)) {
            PlayerPrefs.SetInt(currentLevel, rank);
        }
    }
}
