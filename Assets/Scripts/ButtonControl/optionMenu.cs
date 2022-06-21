using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OptionMenu : MonoBehaviour
{

    [SerializeField] GameObject menu;
    public bool isGamePaused = false;
    public bool isMenuToggled = false;



    private void Update() {
        // if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            // Debug.Log("outside");
        if (isMenuToggled) {
            isMenuToggled = false;
            Debug.Log("hello");

            if (isGamePaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
        // }
        InputSystem.Update();
    }

    public void ReloadMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void PauseGame() {
        menu.SetActive(true);
        // bug should be set to 0f
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void ResumeGame() {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void ToggleMenu() {
        isMenuToggled = true;
    }
}
