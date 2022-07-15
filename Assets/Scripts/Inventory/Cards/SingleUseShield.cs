using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUseShield : Card
{
    private void Awake() {
        cardName = "SINGLE USE SHIELD";
        cardType = "Shield";
        cardDetail = "Made of paper";
        time = 120f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.shieldCount = 1;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.shieldCount = 0;
    }
}
