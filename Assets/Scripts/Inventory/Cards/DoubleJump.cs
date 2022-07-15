using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Card
{
    private void Awake() {
        cardName = "DOUBLE JUMP";
        cardType = "Jump";
        cardDetail = "Jump twice in a row.";
        time = 15f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.maxMultipleJumpTimes = 1;
        PlayerController.instance.isAllowedToMultipleJump = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.maxMultipleJumpTimes = 1;
        PlayerController.instance.isAllowedToMultipleJump = false;
    }
}
