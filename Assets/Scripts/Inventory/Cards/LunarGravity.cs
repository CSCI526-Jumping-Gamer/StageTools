using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarGravity : Card
{
    private void Awake() {
        cardName = "LunarGravity (Gravity -50%)";
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
