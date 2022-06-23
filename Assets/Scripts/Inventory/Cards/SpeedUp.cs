using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Card
{
    private void Awake() {
        cardName = "Running Speed + 20%";
        time = 60f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.moveSpeedMultiplier = 1.5f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.moveSpeedMultiplier = 1f;
    }
}
