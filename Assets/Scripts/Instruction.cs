using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Instruction : MonoBehaviour
{
    [SerializeField] GameObject wrapper;
    void Update() {
        if (Keyboard.current.escapeKey.isPressed && wrapper.activeSelf) {
            CloseWrapper();
        }
    }
    public void CloseWrapper() {
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
        Time.timeScale = 1f;
    }
}
