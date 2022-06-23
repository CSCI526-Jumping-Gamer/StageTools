using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card3SpeedUp : MonoBehaviour
{
    public PlayerCard cardController;
    [SerializeField] PlayerController playerController;
    public bool cardEnabled = false;
    public int cardNumber = 3;
    public string cardName = "Running Speed + 20%";
    public float cardTime = 60f;
    public int cardRank = 1;
    [SerializeField] float moveSpeedMultiplier = 1.2f;
    public void Awake() {
        cardController.enableCard += EnableCard;
        cardController.disableCard += DisableCard;
        // cardController.putCardName += PutHelperName;
        // cardController.putCardTime += PutHelperTime;
        // cardController.putCardRank += PutHelperRank;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableCard(int i) {
        if (i == cardNumber) {
            playerController.moveSpeedMultiplier = moveSpeedMultiplier;
        }
    }
    public void DisableCard(int i) {
        if (i == cardNumber) {
            playerController.moveSpeedMultiplier = 1f;
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
