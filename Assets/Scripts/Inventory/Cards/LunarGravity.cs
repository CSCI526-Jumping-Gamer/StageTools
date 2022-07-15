using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarGravity : Card
{
    private void Awake() {
        cardName = "LUNAR GRAVITY";
        cardDetail = "Gravity -50%";
        cardType = "Gravity";
        time = 20f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        PlayerController.instance.normalGravityScale = 4f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.instance.normalGravityScale = 8f;
    }
}
