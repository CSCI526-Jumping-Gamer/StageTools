using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Inventory/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public float time;
    public int rank;

    public virtual void Activate() {}

    public virtual void Deactivate() {}
}
