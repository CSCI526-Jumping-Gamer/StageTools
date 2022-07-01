using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.2f;
    public Vector3 CheckPointPosition;
    PlayerController playerController;
    Collider2D PlayerCollider;
    CardPanel cardPanel;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        cardPanel = FindObjectOfType<CardPanel>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerCollider = other;
            playerController.OnDisable();
            // cardPanel.InitializeCardPool();
            cardPanel.StartCardPanel();
            Invoke("Respawning", loadDelay);
        }
    }

    public void Respawning()
    {
        // Rigidbody2D otherRb2d = PlayerCollider.gameObject.GetComponent<Rigidbody2D>();
        // playerController.transform.position = playerController.GetCheckPointPosition();
        playerController.transform.position = CheckPointPosition;
        playerController.OnEnable();
    }
}
