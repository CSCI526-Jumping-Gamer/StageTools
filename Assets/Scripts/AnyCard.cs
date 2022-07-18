using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyCard : MonoBehaviour
{
    [SerializeField] Card card;
    bool CardTriggered;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !CardTriggered && Inventory.instance.cards.Count <= 1) {
            Inventory.instance.Add(card);
            CardTriggered = true;
            Invoke("DestroyWithLatency", 0.2f);
        }
    }

    void DestroyWithLatency()
    {
        Destroy(gameObject);
    }
}
