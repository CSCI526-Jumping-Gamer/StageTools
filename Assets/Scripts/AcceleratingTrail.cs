using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingTrail : MonoBehaviour
{
    [SerializeField] float baseSpeed = 14f;
    [SerializeField] float horizontalAccelerateSpeed = 4f;
    [SerializeField] float verticalAccelerateSpeed = 4f;
    DeltaDnaEventHandler deltaDnaEventHandler;

    public bool isTriggered = false;
    bool boosterRecordHelper = true;
    
    private void Awake() {
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = true;
            Accelerate(other);
            if (boosterRecordHelper) {
                string toolName = transform.parent.name;
                int toolID = transform.parent.GetInstanceID();
                deltaDnaEventHandler.RecordtoolsUsage(toolName, "Accelerator", toolID);
                boosterRecordHelper = false;
                // analytics
            }
        }
    }

    private void Accelerate(Collider2D other) {
        // Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
        float angle;
        
        if (transform.rotation.z < 0) {
            angle = 360 - transform.eulerAngles.z;
            angle = 90 - angle;
        } else {
            angle = transform.eulerAngles.z;
            angle = 90 - angle;
        }

        float xSpeed = baseSpeed * horizontalAccelerateSpeed * Mathf.Cos(angle / 180 * Mathf.PI);
        float ySpeed = baseSpeed * verticalAccelerateSpeed * Mathf.Sin(angle / 180 * Mathf.PI);

        if (transform.rotation.z <= 0) {
            otherRb2d.velocity = new Vector2(xSpeed, ySpeed);
        } else if (transform.rotation.z > 0) {
            otherRb2d.velocity = new Vector2(-xSpeed, ySpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            isTriggered = false;
            boosterRecordHelper = true;
        }
    }
}
