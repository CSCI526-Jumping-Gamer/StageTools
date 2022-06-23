using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotHelper : Card
{
    public bool isHelperEnabled = false;

    private void Awake() {
        cardName = "Slingshot Helper";
        time = 3f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        isHelperEnabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        isHelperEnabled = false;
    }
}
