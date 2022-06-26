using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleJump : Card
{
    private void Awake() {
        cardName = "Triple Jump";
        time = 10f;
        rank = 3;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.maxMultipleJumpTimes = 2;
        PlayerController.instance.isAllowedToMultipleJump = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.maxMultipleJumpTimes = 2;
        PlayerController.instance.isAllowedToMultipleJump = false;
    }
}
