using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    Rigidbody2D rb2d;
    Magnet magnet;
    [SerializeField] GameObject magnetGameObject;

    
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        rb2d = magnetGameObject.GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
    }
    private void Update() {
        if (rb2d.transform.localScale != new Vector3(1, 1, 1)) {
            transform.localScale = new Vector3(1 / rb2d.transform.localScale.x, 1 / rb2d.transform.localScale.y, 1 / rb2d.transform.localScale.z);
        }
        if (rb2d.transform.localRotation != new Quaternion(0, 0, 0, 0)) {
            transform.eulerAngles = new Vector3(-rb2d.transform.localRotation.x, -rb2d.transform.localRotation.y, -rb2d.transform.localRotation.z);
        }
    }

    public void DrawRope(Rigidbody2D otherRb2d)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, new Vector3(0f, 0f, 0f));
        lineRenderer.SetPosition(1, otherRb2d.transform.position - transform.position);
    }
    public void DeleteRope() {
        lineRenderer.enabled = false;
    }
}
