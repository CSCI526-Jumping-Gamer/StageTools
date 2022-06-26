using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerController playercontroller;
	public bool isTriggered = false;
	Vector3 FlagCheckPointPosition;

    private void Awake() {
        playercontroller = FindObjectOfType<PlayerController>();
		FlagCheckPointPosition = transform.parent.position;
    }
	
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
			isTriggered = true;
			UpdateCheckPoint(other);
		}
    }
	
	private void UpdateCheckPoint(Collider2D other) {
		
			//Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
			playercontroller.UpdateCheckPointPosition(FlagCheckPointPosition);
		
	}

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
			isTriggered = false;
			Destroy(transform.parent.gameObject);
		}
    }
}
