using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroForceZone : MonoBehaviour
{
    public bool isTriggered;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Card cardHelper = Inventory.instance.SearchHelper();
        SlingshotHelper slingshotHelper = null;

        if (cardHelper) {
            slingshotHelper = (SlingshotHelper)cardHelper;
        }

        if (other.gameObject.tag == "Player" && slingshotHelper && slingshotHelper.isHelperEnabled) {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        // Card card = Inventory.instance.GetFirstCard();
        // SlingshotHelper slingshotHelper = null;

        // if (card && card.GetType() == typeof(SlingshotHelper)) {
        //     slingshotHelper = (SlingshotHelper)card;
        // }

        // if (other.gameObject.tag == "Player" && slingshotHelper && slingshotHelper.isHelperEnabled) {
        isTriggered = false;
        // }
    }
}
