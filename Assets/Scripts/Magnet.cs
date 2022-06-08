using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{

    Rigidbody2D otherRb2d;
    PlayerMovement playerMovement;
    Rigidbody2D rb2d;

    public bool isTriggered = false;
    public bool isCollided = false;
    public float baseDistanceForce = 20f;
    public float magnetForce = 160f;
 
    private void Awake() {
        playerMovement = FindObjectOfType<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (isTriggered) {
            Attract(otherRb2d);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
            // otherRb2d.velocity = new Vector2(0f, 0f);
            this.otherRb2d = otherRb2d;
            playerMovement.SetIsTriggeredWithMagnet(true);
            isTriggered = true;
        }
    }

    void Attract(Rigidbody2D otherRb2d) {
        Vector2 magnetDirection = (transform.position - otherRb2d.transform.position).normalized * Time.fixedDeltaTime;
        float magnetYDirection = Mathf.Abs(magnetDirection.y) - 0.02f > Mathf.Epsilon ? magnetDirection.y : 0f;
        
        // if (Mathf.Abs(magnetDirection.y) ) {
        //     Debug.Log("hello");
        // }

        magnetDirection = new Vector2(magnetDirection.x, magnetYDirection);
        // Debug.Log(magnetDirection);
        float distance = Vector2.Distance(transform.position, otherRb2d.transform.position);
        float distanceFactor = (baseDistanceForce / (distance * distance));
        otherRb2d.AddForce(distanceFactor * magnetForce * magnetDirection, ForceMode2D.Force);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerMovement.SetIsTriggeredWithMagnet(false);
            isTriggered = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        playerMovement.SetIsCollidedWithMagnet(true);
        otherRb2d.velocity = new Vector2(0f, 0f);
        isCollided = true;
    }

    private void OnCollisionExit2D(Collision2D other) {
        playerMovement.SetIsCollidedWithMagnet(false);
        isCollided = false;
    }


}
 