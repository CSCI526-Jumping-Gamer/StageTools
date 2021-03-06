using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : Card
{
    private void Awake() {
        cardName = "ZERO GRAVITY";
        cardDetail = "Move completely gravity-free with WASD.";
        cardType = "Gravity";
        time = 5f;
        rank = 3;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.isAllowedToFly = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.isAllowedToFly = false;
    }
}
