using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MagneticField : MonoBehaviour
{
    Rigidbody2D otherRb2d;
    PlayerController playerController;
    Rigidbody2D rb2d;
    [SerializeField] GameObject magneticLineGameObject;
    MagneticLine magneticLine;
    [SerializeField] GameObject magnetHelperGameObject;
    ZeroForceZone zeroForceZone;

    public bool isTriggered = false;
    public float baseDistanceForce = 10f;
    public float magnetForce = 30f;
    [SerializeField] private bool isMagnetAttractable;
    [SerializeField] private bool isSlingShot;
    [SerializeField] private bool isRailgun;
    DeltaDnaEventHandler deltaDnaEventHandler;
    bool magnetRecordHelper = true;

    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();        
        rb2d = GetComponentInParent<Rigidbody2D>();
        magneticLine = magneticLineGameObject.GetComponent<MagneticLine>();
        deltaDnaEventHandler = FindObjectOfType<DeltaDnaEventHandler>();

        if (isSlingShot) {
            zeroForceZone = magnetHelperGameObject.GetComponent<ZeroForceZone>();
        }
    }

    private void Update() {
        if (isTriggered && playerController.GetIsMagnetized()) {
            if (magnetRecordHelper) {
                string toolName, toolType, toolKey;
                if (isSlingShot) {
                    toolName = transform.parent.parent.name;
                    toolType = "Slingshot";
                    toolKey = toolType + transform.parent.parent.GetInstanceID();
                } else if (isMagnetAttractable) {
                    toolName = transform.parent.parent.name;
                    toolType = "Rope with Magnet";
                    toolKey = toolType + transform.parent.parent.GetInstanceID();
                } else if (isRailgun){
                    toolName = transform.parent.parent.parent.name;
                    toolType = "Railgun";
                    toolKey = toolType + transform.parent.parent.parent.GetInstanceID();
                } else {
                    toolName = transform.parent.name;
                    toolType = "Magnet";
                    toolKey = toolType + transform.parent.GetInstanceID();
                }
                deltaDnaEventHandler.RecordtoolsUsage(toolName, toolType, toolKey);
                magnetRecordHelper = false;
            }
            magneticLine.DrawRope(otherRb2d);
        } else {
            magnetRecordHelper = true;
            magneticLine.DeleteRope();
        }
    }
    private void FixedUpdate() {
        if (isSlingShot) {
            if (isTriggered && playerController.GetIsMagnetized() && !zeroForceZone.isTriggered) {
                Attract(otherRb2d);
            }
        } else {
            if (isTriggered && playerController.GetIsMagnetized()) {
                Attract(otherRb2d);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
            // Rigidbody2D otherRb2d = other.GetComponent<Rigidbody2D>();
            // otherRb2d.velocity = new Vector2(0f, 0f);
            this.otherRb2d = otherRb2d;
            playerController.SetIsTriggeredWithMagnet(true);
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
        if (isMagnetAttractable) {
            rb2d.AddForce(distanceFactor * magnetForce * -magnetDirection, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerController.SetIsTriggeredWithMagnet(false);
            isTriggered = false;
        }
    }
}
