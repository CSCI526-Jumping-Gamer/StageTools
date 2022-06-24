using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeClimber : Card
{
    private void Awake() {
        cardName = "RopeClimber (Climbing Speed + 100%)";
        time = 60f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.climbSpeed = 16f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.climbSpeed = 8f;
    }
}
