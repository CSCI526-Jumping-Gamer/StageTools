using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{
    PlayerMovement playerMovement;
    BoxCollider2D boxCollider2D;
    [SerializeField] GameObject magneticFieldGameObject;
    MagneticField magneticField;

    public bool isCollided = false;

    private void Awake() {
        playerMovement = FindObjectOfType<PlayerMovement>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        magneticField = magneticFieldGameObject.GetComponent<MagneticField>();
    }

    private void FixedUpdate() {
        PhysicsMaterial2D material = new PhysicsMaterial2D();

        if (magneticField.isTriggered && playerMovement.GetIsMagnetized()) {
            material.friction = 0.4f;
        } else {
            material.friction = 0f;
        }

        boxCollider2D.sharedMaterial = material;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        playerMovement.SetIsCollidedWithMagnet(true);
        Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
        otherRb2d.velocity = new Vector2(0f, 0f);
        isCollided = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        playerMovement.SetIsCollidedWithMagnet(false);
        isCollided = false;
    }
}
 