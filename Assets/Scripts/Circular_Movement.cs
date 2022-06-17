using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circular_Movement : MonoBehaviour
{
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius = 2f;
    [SerializeField] float angularSpeed = 2f;
    [SerializeField] bool clockwise = false;
    float posX, posY, angle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float c = 1f;
        if (clockwise) c = -1f;        
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle= angle + Time.deltaTime * angularSpeed * c;
        if (angle >= 360f) angle = 0f;

    }
}
