using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetHelper : MonoBehaviour
{
    
    public bool HelperEnabled = false;
    public bool HelperSwitch;
    public Card1MagnetHelper helperController;

    private void Awake() {
        // helperController = GameObject.FindWithTag();
    }

    public void Start() {

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && helperController.HelperEnabled) {
            HelperSwitch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && helperController.HelperEnabled) {
            HelperSwitch = false;
        }
    }
}
