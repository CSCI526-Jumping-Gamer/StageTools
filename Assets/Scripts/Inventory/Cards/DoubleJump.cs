using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Card
{
    private void Awake() {
        cardName = "Double Jump";
        time = 3f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.SetIsAllowedDoubleJump(true);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.SetIsAllowedDoubleJump(false);
    }
}
