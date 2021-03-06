using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string  LevelSelector = "LevelSelect";
    public void PlayGame() {
        // Debug.Log("Play!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        BackgroundMusic.isLoadMusic = true;
        BackgroundMusic.isMusicContinue = false;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenLevels() {
        SceneManager.LoadScene(LevelSelector);
    }
}
