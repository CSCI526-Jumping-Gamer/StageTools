using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectorVariant : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.parent = transform;
			ActivatePlane(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            other.transform.parent = null;
			// DeactivePlane(false);
        }
    }
	
	private void ActivatePlane(bool isActivated) {
		gameObject.GetComponentInParent<MovingObjectVariant>().PullTrigger(isActivated);
	}
	
	private void DeactivePlane(bool isActivated) {
		gameObject.GetComponentInParent<MovingObjectVariant>().PullTrigger(isActivated);
	}
}
