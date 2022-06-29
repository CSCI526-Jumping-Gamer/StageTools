using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : UtilityTool
{
    PlayerController playerController;
    BoxCollider2D boxCollider2D;
    [SerializeField] GameObject magneticFieldGameObject;
    MagneticField magneticField;


    public bool isCollided = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        magneticField = magneticFieldGameObject.GetComponent<MagneticField>();
    }

    private void Start()
    {
        if (specificType == "Magnet")
        {
            toolName = transform.name;
        }
        else if (specificType == "Slingshot")
        {
            toolName = transform.parent.name;
        }
        else if (specificType == "Rope with Magnet")
        {
            toolName = transform.parent.name;
        }
        else if (specificType == "Railgun")
        {
            toolName = transform.parent.parent.name;
        }

        category = "Magnet";
        id = specificType + " (" + transform.GetInstanceID() + ")";
    }

    private void FixedUpdate()
    {
        PhysicsMaterial2D material = new PhysicsMaterial2D();

        if (magneticField.isTriggered && playerController.GetIsMagnetized())
        {
            material.friction = 0.4f;
        }
        else
        {
            material.friction = 0f;
        }

        boxCollider2D.sharedMaterial = material;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.SetIsCollidedWithMagnet(true);
            // Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
            // otherRb2d.velocity = new Vector2(0f, 0f);
            isCollided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.SetIsCollidedWithMagnet(false);
            isCollided = false;
        }
    }
}
