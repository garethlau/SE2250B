using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagonal : Enemy
{
    // Set the speed of movement
    public float speed = 10f;

    // Private variable to determine direction of movement
    private bool moveLeft;

    void Start()
    {

        // Randomly set movement direction
        if (Random.value >= 0.5)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }

    void Update()
    {
        // Call the movement function
        Move();
        // Check if the game object is out of bounds
        base.CheckOutOfBounds();
    }

    // Define a variable to get and set the position of the game object
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    public virtual void Move()
    {
        // Get the current position
        Vector3 tempPos = pos;

        // Move the game object down
        tempPos.y -= speed * Time.deltaTime;
        
        if (moveLeft)
        {
            // Move the game object to the left
            tempPos.x -= speed * Time.deltaTime;
        }
        else
        {
            // Move the game object to the right
            tempPos.x += speed * Time.deltaTime;
        }

        // Apply the transform to the game object
        pos = tempPos;

    }
}
