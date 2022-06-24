using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerAccelerator : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] float baseSpeed = 14f;
    [SerializeField] float horizontalAccelerateSpeed = 4f;
    [SerializeField] float verticalAccelerateSpeed = 4f;

    public bool isTriggered = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if ((other.tag == "Player") || (other.tag == "Rope"))
        {
            isTriggered = true;
            // playerMovement.DisablePlayerInput();
            // playerMovement.EnablePlayerInputWithDelay(0.1f);
            Accelerate(other);
        }
    }

    private void Accelerate(Collider2D other)
    {
        // Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
        float angle;

        if (transform.rotation.z < 0)
        {
            angle = 360 - transform.eulerAngles.z;
            angle = 90 - angle;
        }
        else
        {
            angle = transform.eulerAngles.z;
            angle = 90 - angle;
        }

        float xSpeed = baseSpeed * horizontalAccelerateSpeed * Mathf.Cos(angle / 180 * Mathf.PI);
        float ySpeed = baseSpeed * verticalAccelerateSpeed * Mathf.Sin(angle / 180 * Mathf.PI);

        if (transform.rotation.z <= 0)
        {
            otherRb2d.velocity = new Vector2(xSpeed, ySpeed);
        }
        else if (transform.rotation.z > 0)
        {
            otherRb2d.velocity = new Vector2(-xSpeed, ySpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.tag == "Player") || (other.tag == "Rope"))
        {
            isTriggered = false;
        }
    }
}
