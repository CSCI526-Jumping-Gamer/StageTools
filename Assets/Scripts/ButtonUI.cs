using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] List<InputActionReference> inputActionReference;
    void Start() {
        UpdateButtonUI();
    }
    void UpdateKeyBinding(int i) {
        GameObject gameObject = transform.GetChild(0).GetChild(i).GetChild(0).GetChild(0).gameObject;
        if (inputActionReference[i].action != null){
            TextMeshProUGUI textMeshProUGUI = gameObject.transform.GetComponent<TextMeshProUGUI>();
            var actionName = inputActionReference[i].action.name;
            textMeshProUGUI.text = InputManager.GetBindingName(actionName, 0);
        }
    }
    public void UpdateButtonUI() {
        for (int i = 0; i < inputActionReference.Count; i++) {
            UpdateKeyBinding(i);
        }
    }
}
