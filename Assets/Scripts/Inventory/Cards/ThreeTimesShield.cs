using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeTimesShield : Card
{
    private void Awake() {
        cardName = "Three-Times Shield";
        time = 30f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.shieldCount = 3;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.shieldCount = 0;
    }
}
