using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rope : MonoBehaviour
{
    Transform trans;
    PlayerMovement playerMovement;
    Rigidbody2D rb2d;
    HingeJoint2D hingeJoint2D;

    private void Awake() {
        trans = GetComponent<Transform>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            if (playerMovement.GetIsHoldingRope() && !Keyboard.current.spaceKey.isPressed) {
                playerMovement.SetRope(this);
                Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
                otherRb2d.position = transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
    }
}
