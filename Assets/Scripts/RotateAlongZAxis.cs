using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAlongZAxis : MonoBehaviour
{
    private float angle;
    [SerializeField] float rotationSpeed = 50f;
    [SerializeField] bool clockwiseRotation = false;

    // Update is called once per frame
    void Update()
    {
        if (clockwiseRotation == false)
        {
            angle += Time.deltaTime * rotationSpeed;
        }
        else
        {
            angle += -Time.deltaTime * rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
