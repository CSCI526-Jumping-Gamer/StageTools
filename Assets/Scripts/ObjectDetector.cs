using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.parent = null;
			other.transform.localEulerAngles = new Vector3(0,0,0);
        }
    }
}
