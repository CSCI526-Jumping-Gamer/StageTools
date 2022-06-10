using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 200f;
    
    private Vector3 rot;
    private Transform trans;
    [SerializeField] float angle = 90f;
    [SerializeField] bool isAround = true;
    [SerializeField] bool clockWise = true;
    
    void Awake() {
        trans = transform;
        rot = new Vector3(0, 0 ,0);
    }
    void Update()
    {
        rot.z = clockWise ? -1 : 1;
        if (isAround) {
            trans.Rotate(rot * rotateSpeed * Time.deltaTime, Space.Self);
        } else {
            trans.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, angle * 2) - 45);
        }
    }
}
