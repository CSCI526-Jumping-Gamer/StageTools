using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Instruction : MonoBehaviour
{
    [SerializeField] GameObject wrapper;
    [SerializeField] GameObject settingPanel;
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed && wrapper.activeSelf)
        {
            CloseWrapper();
        }
    }
    public void CloseWrapper()
    {
        wrapper.SetActive(false);
        settingPanel.SetActive(true);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }
}
