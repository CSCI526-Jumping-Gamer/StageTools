using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rope : MonoBehaviour
{
    // Start is called before the first frame update
    Transform trans;

    PlayerMovement playerMovement;
    Rigidbody2D rb2d;


    private void Awake() {
        trans = GetComponent<Transform>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        playerMovement.SetRope(this);
        // Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
        // otherRb2d.velocity = new Vector2(0f, 0f);
    }

    private void OnTriggerStay2D(Collider2D other) {
        // if (other.tag == "Player") {
        //     if (!Keyboard.current.spaceKey.isPressed) {
        //         Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
        //         otherRb2d.position = transform.position;
        //     }
        // }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // rb2d.velocity = new Vector2(0f, 0f);
    }
}
