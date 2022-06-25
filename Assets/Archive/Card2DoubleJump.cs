using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card2DoubleJump : MonoBehaviour
{
    public PlayerCard cardController;
    [SerializeField] PlayerController playerController;
    public bool cardEnabled = false;
    public int cardNumber = 2;
    public string cardName = "Double Jump";
    public float cardTime = 30f;
    public int cardRank = 2;
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
            playerController.SetIsAllowedDoubleJump(true);
        }
    }
    public void DisableCard(int i) {
        if (i == cardNumber) {
            playerController.SetIsAllowedDoubleJump(false);
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
