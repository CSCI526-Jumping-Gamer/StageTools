using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerController playercontroller;
	public bool isTriggered = false;
	Vector3 FlagCheckPointPosition;
	[SerializeField] GameObject glow;

    private void Awake() {
        playercontroller = FindObjectOfType<PlayerController>();
		FlagCheckPointPosition = transform.parent.position;
		glow.SetActive(false);
    }
	
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
			isTriggered = true;
			UpdateCheckPoint(other);
			glow.SetActive(true);
		}
    }
	
	private void UpdateCheckPoint(Collider2D other) {
		
			//Rigidbody2D otherRb2d = other.gameObject.GetComponent<Rigidbody2D>();
			playercontroller.UpdateCheckPointPosition(FlagCheckPointPosition);
		
	}

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
			isTriggered = false;
		}
    }
}
