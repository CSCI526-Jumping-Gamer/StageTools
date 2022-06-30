using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            playerController.SetIsChildOfMagnet(true);
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            playerController.SetIsChildOfMagnet(false);
            other.transform.parent = null;
			other.transform.localEulerAngles = new Vector3(0,0,0);
        }
    }
}
