using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] GameObject wrapper;

    public void CloseWrapper() {
        wrapper.SetActive(false);
        PlayerController.instance.EnablePlayerInput();
    }
}
