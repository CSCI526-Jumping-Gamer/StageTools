using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Card
{
    private void Awake() {
        cardName = "Flash (Running Speed + 100%)";
        time = 15f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.moveSpeedMultiplier = 2f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.moveSpeedMultiplier = 1f;
    }
}
