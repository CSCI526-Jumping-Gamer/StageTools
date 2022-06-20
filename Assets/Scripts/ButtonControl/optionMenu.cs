using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionMenu : MonoBehaviour
{

    [SerializeField] GameObject Menu;
    public void reloadMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void pauseGame() {
        Menu.SetActive(true);
        // bug should be set to 0f
        Time.timeScale = 1f;
    }

    public void resumeGame() {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
