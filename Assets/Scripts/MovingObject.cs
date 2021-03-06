using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 currentDestination;
    int currentDestinationIndex = -1;
    float delayStart;
    [SerializeField] float tolerance;

    [SerializeField] Vector3[] destinations;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDelay = 2f;
    [SerializeField] bool automatic = true;

    void Start()
    {
        startPosition = transform.position;
        currentDestination = transform.position;
        tolerance = moveSpeed * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        if (destinations.Length > 0)
        {
            Vector3 heading = (currentDestination - transform.position);

            if (heading.magnitude >= tolerance)
            {
                MoveObject();
            }
            else
            {
                UpdateDestination();
            }
        }
    }

    void MoveObject()
    {
        Vector3 heading = (currentDestination - transform.position);
        transform.position += heading.normalized * moveSpeed * Time.fixedDeltaTime;
        heading = (currentDestination - transform.position);

        if (heading.magnitude < tolerance)
        {
            transform.position = currentDestination;
            delayStart = Time.time;
        }
    }

    void UpdateDestination()
    {
        if (automatic)
        {
            if (Time.time - delayStart > moveDelay)
            {
                currentDestinationIndex++;
                currentDestination = GetNextDestination();
            }
        }
    }

    public Vector3 GetNextDestination()
    {
        if (currentDestinationIndex == destinations.Length)
        {
            currentDestinationIndex = -1;
            return startPosition;
        }
        else
        {
            return destinations[currentDestinationIndex];
        }
    }
}
