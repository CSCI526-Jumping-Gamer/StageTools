using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    [SerializeField] float startAngle = 0f;
    [SerializeField] float endAngle = 90f;
    [SerializeField] float duration = 2f;
    [SerializeField] float selfRotateSpeed = 40f;
    [SerializeField] bool isFullRotate = false;
    
    private void Start() {

    }

    private void Update() {
        if (isFullRotate) {
            transform.Rotate(new Vector3(0, 0, selfRotateSpeed) * Time.deltaTime);
        } else {
            float currentAngle = Mathf.SmoothStep(startAngle, endAngle, Mathf.PingPong(Time.time / duration, 1));
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);
        }
    }
}
