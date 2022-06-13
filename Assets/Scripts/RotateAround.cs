using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    private Vector3 axis;
    
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] bool isClockWise = true;
    [SerializeField] GameObject pivot;

    void Awake() {
        axis = new Vector3(0, 0, 0);   
    }

    void Update()
    {
        axis.z = isClockWise ? -1 : 1;
        transform.RotateAround(pivot.transform.position, axis, rotateSpeed * Time.deltaTime);
    }
}
