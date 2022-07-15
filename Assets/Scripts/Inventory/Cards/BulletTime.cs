using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : Card
{
    private void Awake() {
        cardName = "BULLET TIME";
        cardType = "Other";
        cardDetail = "Time flow will be slowed down to 1/2.";
        time = 5f;
        rank = 2;
    }
    public override void Activate()
    {
        base.Activate();
        Time.timeScale = 0.5f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Time.timeScale = 1f;
    }
}
