using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroForceZone : MonoBehaviour
{
    public bool isTriggered;
    
    private void OnTriggerEnter2D(Collider2D other) {
        SlingshotHelper slingshotHelper = (SlingshotHelper)Inventory.instance.GetFirstCard();

        if (other.gameObject.tag == "Player" && slingshotHelper.isHelperEnabled) {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        SlingshotHelper slingshotHelper = (SlingshotHelper)Inventory.instance.GetFirstCard();

        if (other.gameObject.tag == "Player" && slingshotHelper.isHelperEnabled) {
            isTriggered = false;
        }
    }
}
