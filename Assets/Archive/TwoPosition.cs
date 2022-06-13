using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPosition : MonoBehaviour
{

    private Transform child;
    private Transform curr; 
    [SerializeField] float moveSpeed = 10f;


    private Vector3 startPos;
    void Awake()
    {
        curr = GameObject.FindWithTag("MoveObject").transform;
        child = transform.Find("NewPosition");
        startPos = curr.position;
    }

    // Update is called once per frame
    void Update()
    {
        curr.position = Vector3.Lerp(startPos, child.position, Mathf.PingPong(Time.time * moveSpeed, 1f));

    }


}