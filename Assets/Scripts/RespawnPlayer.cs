using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.2f;
    // [SerializeField] Vector3 CheckPointPosition;
    PlayerController playerController;
    Collider2D PlayerCollider;
    // Teleporter teleporter;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        // teleporter = FindObjectOfType<Teleporter>();
    }
    // void Start() {
    //     CheckPointPosition = teleporter.CheckPointPosition;
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerCollider = other;
            playerController.OnDisable();
            Invoke("Respawning", loadDelay);
        }
    }

    public void Respawning()
    {
        Rigidbody2D otherRb2d = PlayerCollider.gameObject.GetComponent<Rigidbody2D>();
        otherRb2d.transform.position = playerController.GetCheckPointPosition();
        playerController.OnEnable();
    }
}
