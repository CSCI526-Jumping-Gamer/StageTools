using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObjectRotate : MonoBehaviour
{
	public float RotateSpeed;
	private Vector3 zAxis;
	private Vector3 anchorPosition;
	private float Count = 0.0f;
	public GameObject target;

	// Start is called before the first frame update
    void Start()
    {
        anchorPosition = Vector3.zero;
		zAxis = new Vector3(0, 0, 1);
		//List<Transform> children = new();
		
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            //children.Add(child);
			//Debug.Log(child.position);
			anchorPosition += child.position;
			Count += 1.0f;
        }
		
		anchorPosition = anchorPosition / Count;

        //Debug.Log("Count: " + children.Count);
		
    }

    // Update is called once per frame
    //private void FixedUpdate()
  	void Update()
    {
		//transform.RotateAround(anchorPosition, zAxis, Time.deltaTime*AngleSpeed);
		RotateByDegrees();
    }
	
	void RotateByDegrees()
    {
        //transform.Rotate(new Vector3(0, 0, RotateSpeed) * Time.deltaTime); 
		//cube1.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
		transform.RotateAround(anchorPosition, zAxis, RotateSpeed * Time.deltaTime);

    }

}
