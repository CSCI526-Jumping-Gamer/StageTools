using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyCard : MonoBehaviour
{
    [SerializeField] Card card;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Inventory.instance.Add(card);
        Invoke("DestroyWithLatency", 0.2f);
    }

    void DestroyWithLatency()
    {
        Destroy(gameObject);
    }
}