using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.2f;
    [SerializeField] Vector3 CheckPointPosition;
    PlayerMovement playerMovement;
    Collider2D PlayerCollider;
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            PlayerCollider = other;
            playerMovement.OnDisable();
            Invoke("Respawning", loadDelay);
        }
    }

    void Respawning() {
		Rigidbody2D otherRb2d = PlayerCollider.gameObject.GetComponent<Rigidbody2D>();
		otherRb2d.transform.position = CheckPointPosition;
        playerMovement.OnEnable();
	}
}
