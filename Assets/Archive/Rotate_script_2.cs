using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_script_2 : MonoBehaviour
{
    private float rot;
    [SerializeField] public float speed;
    [SerializeField] public bool clockwise;
    // Update is called once per frame
    void Update()
    {
        if (!clockwise) rot += Time.deltaTime * speed;
        else rot += -Time.deltaTime * speed;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        Vector3 position = new Vector3 (3, 3, 0);
        transform.RotateAround(position,Vector3.forward, Time.deltaTime * speed);
    }
}
