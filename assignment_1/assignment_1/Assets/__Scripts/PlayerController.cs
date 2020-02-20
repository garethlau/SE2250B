using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Declare variables
	public float speed;
    public Text countText;
	public Text winText;

	public int totalItems;
	private int remainingItems;

	private Rigidbody rb;
	private int count; 
	
	void Start() {
		remainingItems = totalItems;    // Set the number of remaining items equal to the total number of items
		rb = GetComponent<Rigidbody>(); // Get the ball object
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// Performed before any physics is executed
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        // Create new force vector based on horizontal and vertical input
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // Apply force vector to the ball
        rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
        // Check if collision occured with a pickup
		if (other.gameObject.CompareTag("CylinderPickup") || other.gameObject.CompareTag("RectPickup") || other.gameObject.CompareTag("SpherePickup")) {
			other.gameObject.SetActive(false);  // Deactivate the pickup
			int points;
			remainingItems--;   // Reduce the number of remaining items

            // Check what object the ball collided with and set the points accordingly
            if (other.gameObject.CompareTag("CylinderPickup")) {
				points = 3;
			}
			else if (other.gameObject.CompareTag("RectPickup")) {
				points = 2;
			}
			else {
				points = 1;
			}
            Destroy(other.gameObject);
			count = count + points; // Update the point total
			SetCountText(); // Display the point total 
		}	
	}

    // Helper method to display the score
	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (remainingItems == 0) {
			remainingItems = totalItems;
			winText.text = "You win!";
			// restart the game
			Invoke("RestartGame", 2);
		}
	}

    // Helper method to restart the game
	void RestartGame() {
		count = 0;  // reset the score
		SetCountText();

        // Reset the position of the ball
		transform.position = new Vector3(0f, 0f, 0f);

        // Remove all velocities on the ball
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero; 

        // Reset the win text
		winText.text = "";

        // Spawn the pickup objects
		GetComponent<SpawnItems>().Spawn();
	}
}
