using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Create and apply rotation vector based on current time
		transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);       
    }
}
