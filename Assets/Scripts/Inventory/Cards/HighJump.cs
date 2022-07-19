using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJump : Card
{
    private void Awake() {
        cardName = "HIGH JUMP";
        cardType = "Jump";
        cardDetail = "Jumping Height + 40%";
        time = 30f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.jumpSpeedMultiplier = 1.4f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.jumpSpeedMultiplier = 1f;
    }
}
