using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.2f;
    public Vector3 CheckPointPosition;
    PlayerController playerController;
    Collider2D PlayerCollider;
    RandomCards randomCards;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        randomCards = FindObjectOfType<RandomCards>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerCollider = other;
            playerController.OnDisable();
            Invoke("Respawning", loadDelay);
            randomCards.StartCardPanel();
        }
    }

    public void Respawning()
    {
        Rigidbody2D otherRb2d = PlayerCollider.gameObject.GetComponent<Rigidbody2D>();
        otherRb2d.transform.position = CheckPointPosition;
        playerController.OnEnable();
    }
}
