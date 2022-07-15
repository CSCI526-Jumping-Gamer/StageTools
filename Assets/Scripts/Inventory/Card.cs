using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "New Card", menuName = "Inventory/Card")]
public class Card : MonoBehaviour
{
    public string cardName;
    public string cardDetail;
    public string cardType;
    public float time;
    public int rank;

    public virtual void Activate() {}

    public virtual void Deactivate() {}
}
