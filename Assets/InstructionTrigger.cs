using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionTrigger : MonoBehaviour
{
    bool isFirstTime = true;
    [SerializeField] GameObject window;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (isFirstTime) {
                PlayerController.instance.DisablePlayerInput();
                window.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isFirstTime = false;
    }
}
