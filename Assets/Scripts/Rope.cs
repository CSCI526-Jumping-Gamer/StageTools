using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rope : UtilityTool
{
    Transform trans;
    PlayerController playerController;
    Rigidbody2D rb2d;
    HingeJoint2D hingeJoint2D;
    DeltaDnaEventHandler deltaDnaEventHandler;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        playerController = FindObjectOfType<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        hingeJoint2D = GetComponent<HingeJoint2D>();
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
    }

    void Start()
    {
        // Rigidbody2D[] rb2dArray = GetComponentsInParent<Rigidbody2D>();
        // transform.parent.GetChildCount
        // Debug.Log(transform.parent.GetChild(0).position); 
        toolName = transform.name;
        category = "Rope";
        id = category + " (" + transform.GetInstanceID() + ")";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (playerController.GetIsHoldingRope() && !Keyboard.current.spaceKey.isPressed)
            {
                playerController.SetRope(this);
                Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
                otherRb2d.position = transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController.SetRope(null);
            string toolName = transform.parent.name;
            string toolKey = "Rope" + transform.parent.GetInstanceID();
            deltaDnaEventHandler.RecordtoolsUsage(toolName, "Rope", toolKey);
        }
    }
}
