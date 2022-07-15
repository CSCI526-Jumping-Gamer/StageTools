using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Invincible : Card
{
    private void Awake() {
        cardName = "INVINCIBLE";
        cardType = "Shield";
        cardDetail = "Nothing can beat you.";
        time = 5f;
        rank = 3;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.shieldCount = Int32.MaxValue;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.shieldCount = 0;
    }
}
