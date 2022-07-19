using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Card
{
    private void Awake() {
        cardName = "SPEED UP";
        cardType = "Speed";
        cardDetail = "Running Speed + 40%";
        time = 30f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.moveSpeedMultiplier = 1.4f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.moveSpeedMultiplier = 1f;
    }
}
