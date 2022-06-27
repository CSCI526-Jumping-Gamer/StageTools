using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.2f;
    [SerializeField] Vector3 CheckPointPosition;
    CardTimer cardTimer;

    PlayerController playerController;
    Collider2D PlayerCollider;
    // Teleporter teleporter;
    // Start is called before the first frame update
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        cardTimer = FindObjectOfType<CardTimer>();
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
            if (PlayerController.instance.shieldCount > 0) {
                PlayerController.instance.shieldCount -= 1;
                if (PlayerController.instance.shieldCount == 0) {
                    cardTimer.Deactivate();
                }
            } else {
                Debug.Log("2");
                Invoke("Respawning", loadDelay);
            }
        }
    }

    public void Respawning()
    {
        Debug.Log("3");
        Rigidbody2D otherRb2d = PlayerCollider.gameObject.GetComponent<Rigidbody2D>();
        otherRb2d.transform.position = playerController.GetCheckPointPosition();
        playerController.OnEnable();
    }
}
