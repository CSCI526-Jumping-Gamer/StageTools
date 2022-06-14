using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MagneticField : MonoBehaviour
{
    Rigidbody2D otherRb2d;
    PlayerMovement playerMovement;
    Rigidbody2D rb2d;
    [SerializeField] GameObject magneticLineGameObject;
    MagneticLine magneticLine;

    public bool isTriggered = false;
    public float baseDistanceForce = 10f;
    public float magnetForce = 30f;
    [SerializeField] private bool MagnetAttractable;

    private void Awake() {
        playerMovement = FindObjectOfType<PlayerMovement>();        
        rb2d = GetComponentInParent<Rigidbody2D>();
        magneticLine = magneticLineGameObject.GetComponent<MagneticLine>();
    }

    private void Update() {
        if (isTriggered && playerMovement.GetIsMagnetized()) {
            magneticLine.DrawRope(otherRb2d);
        } else {
            magneticLine.DeleteRope();
        }
    }
    private void FixedUpdate() {
        if (isTriggered && playerMovement.GetIsMagnetized()) {
            Attract(otherRb2d);
        } else if (!playerMovement.GetIsMagnetized()){
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
            // Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
            // otherRb2d.velocity = new Vector2(0f, 0f);
            this.otherRb2d = otherRb2d;
            playerMovement.SetIsTriggeredWithMagnet(true);
            isTriggered = true;
        }
    }

    void Attract(Rigidbody2D otherRb2d) {
        Vector2 magnetDirection = (transform.position - otherRb2d.transform.position).normalized;
        // float magnetYDirection = Mathf.Abs(magnetDirection.y) - 0.02f > Mathf.Epsilon ? magnetDirection.y : 0f;
        // magnetDirection = new Vector2(magnetDirection.x, magnetYDirection);
        // Debug.Log(magnetDirection);
        float distance = Vector2.Distance(transform.position, otherRb2d.transform.position);
        float distanceFactor = (baseDistanceForce / (distance * distance));
        otherRb2d.AddForce(distanceFactor * magnetForce * magnetDirection, ForceMode2D.Force);
        if (MagnetAttractable) {
            rb2d.AddForce(distanceFactor * magnetForce * -magnetDirection, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerMovement.SetIsTriggeredWithMagnet(false);
            isTriggered = false;
        }
    }
    // void DrawRope(Rigidbody2D otherRb2d)
    // {
    //     lineRenderer.enabled = true;
    //     lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
    //     lineRenderer.SetPosition(1, otherRb2d.transform.position - transform.position);
    // }
    // void DeleteRope() {
    //     lineRenderer.enabled = false;
    // }
}
