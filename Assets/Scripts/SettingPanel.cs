using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] GameObject wrapper;
    [SerializeField] GameObject rebindingWrapper;
    // [SerializeField] GameObject buttonUI;
    [SerializeField] CardInventoryUI cardInventoryUI;
    [SerializeField] ButtonUI[] buttonUIs;

    private void Awake()
    {
        buttonUIs = FindObjectsOfType<ButtonUI>();
        
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ReBindKey()
    {
        wrapper.SetActive(false);
        rebindingWrapper.SetActive(true);
    }
    public void ReturnToSetting()
    {
        wrapper.SetActive(true);
        rebindingWrapper.SetActive(false);
        foreach(ButtonUI buttonUI in buttonUIs) {
            buttonUI.UpdateButtonUI();
        }
    }

    public void OpenLevels()
    {
        wrapper.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(8);
    }

    public void ReStartLevel()
    {
        wrapper.SetActive(true);
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        wrapper.SetActive(true);
        cardInventoryUI.ActiveCardUI = false;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        wrapper.SetActive(false);
        cardInventoryUI.ActiveCardUI = true;
        Time.timeScale = 1f;
    }
}
