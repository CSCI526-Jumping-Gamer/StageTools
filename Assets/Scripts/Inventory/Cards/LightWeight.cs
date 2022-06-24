using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeight : Card
{
    private void Awake() {
        cardName = "LightWeight (Gravity -25%)";
        time = 40f;
        rank = 1;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.normalGravityScale = 6f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.normalGravityScale = 8f;
    }
}
