using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceUpDn : MonoBehaviour
{
    // Declare variables
	public float speed = 5f;
	public float height = 1.0f;

	private Vector3 initPos;

	void Start() {
        // Set the initial posiiton of the object
		initPos = transform.position;
	}

    void Update()
    {
        // Method to calculate new vertical position as a function of time
        Vector3 pos = transform.position;
		float newY = Mathf.Sin(Time.time * speed);
		transform.position = new Vector3(initPos.x, initPos.y + newY * height, initPos.z);


    }
}
