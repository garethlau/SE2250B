using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Declare variables
	public GameObject player;
    private Vector3 offset;
	
    void Start()
    {
        // Lock the offset of the camera relative to the player object
        offset = transform.position - player.transform.position;
    }

	// Updates only after all other updates are complete
    void LateUpdate()
    {
        // Move the camera relative to hthe player object
        transform.position = player.transform.position + offset;
    }
}
