using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card1MagnetHelper : MonoBehaviour
{
    public PlayerCard cardController;
    public bool HelperEnabled = false;
    public int cardNumber = 1;
    public string cardName = "Magnet Helper";
    public float cardTime = 3f;
    public int cardRank = 2;
    public void Awake() {
        cardController.enableCard += EnableHelper;
        cardController.disableCard += DisableHelper;
        // cardController.putCardName += PutHelperName;
        // cardController.putCardTime += PutHelperTime;
        // cardController.putCardRank += PutHelperRank;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableHelper(int i) {
        if (i == cardNumber) {
            HelperEnabled = true;
        }
    }
    public void DisableHelper(int i) {
        if (i == cardNumber) {
            HelperEnabled = false;
        }
    }
    // string PutHelperName(int i) {
    //     if (i == HelperNumber) {
    //         return HelperName;
    //     }
    //     return null;
    // }
    // float PutHelperTime(int i) {
    //     if (i == HelperNumber) {
    //         return HelperTime;
    //     }
    //     return null;
    // }
    // int PutHelperRank(int i) {
    //     if (i == HelperNumber) {
    //         return HelperRank;
    //     }
    //     return null;
    // }
}
