using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 200f;
    private Vector3 rot;
    [SerializeField] bool clockWise = true;
    
    
    private Vector3 pos;
    private Vector3 fixPos;
    private Transform child;
    private Transform center;
    void Awake() {
        rot = new Vector3(0, 0, 0);   
        child = transform.Find("Target");
        center = transform.Find("Center");
        
    }

    // Update is called once per frame
    void Update()
    {
        rot.z = clockWise ? -1 : 1;
        child.RotateAround(center.position, rot, rotateSpeed * Time.deltaTime);
     
    }
}
