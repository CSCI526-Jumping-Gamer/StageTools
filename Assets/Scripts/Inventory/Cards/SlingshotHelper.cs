using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotHelper : Card
{
    public bool isHelperEnabled = false;

    private void Awake() {
        cardName = "SLINGSHOT HELPER";
        cardType = "Other";
        cardDetail = " On Slingshot it help you automatically release magnetic at the best time";
        time = 15f;
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
