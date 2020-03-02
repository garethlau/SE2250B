using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : Enemy
{
    // Set the movement speed
    public float speed = 10f;


    void Update()
    {
        // Move the object
        Move();
        // Check if the game object is out of bounds
        base.CheckOutOfBounds();
    }

    // Define a variable to set and get the position of the object
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

        // Set the y transform
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;

    }
}
