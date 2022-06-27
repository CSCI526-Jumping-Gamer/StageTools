using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject wrapper;
    [SerializeField] GameObject button;

    private void Awake() {
        button.SetActive(true);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OpenLevels() {
        wrapper.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(7);
    }

    public void PauseGame()
    {
        wrapper.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        wrapper.SetActive(false);
        Time.timeScale = 1f;
    }
}
