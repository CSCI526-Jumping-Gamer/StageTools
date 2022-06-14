using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
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
