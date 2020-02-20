using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum MovementType
    {
        Straight, Diagonal
    }

    [Header("Set In Inspector")]
    public float speed = 10f;
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;
    public MovementType movementType = MovementType.Straight;

    [Header("Set Dynamically")]
    private BoundsCheck boundsCheck;
    private bool moveLeft;

    private void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    public void Start()
    {
        if (movementType == MovementType.Diagonal)
        {
            if (Random.value >= 0.5)
            {
                moveLeft = true;
            }
            else
            {
                moveLeft = false;
            }
        }
    }

    public Vector3 pos
    {
        get {
            return (this.transform.position);
        }
        set {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();    

        if (boundsCheck != null && boundsCheck.offDown)
        {
           Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        if (movementType == MovementType.Straight)
        {
            tempPos.y -= speed * Time.deltaTime;
        }
        else if (movementType == MovementType.Diagonal)
        {
            tempPos.y -= speed * Time.deltaTime;
            if (moveLeft)
            {
                tempPos.x -= speed * Time.deltaTime;
            }
            else
            {
                tempPos.x += speed * Time.deltaTime;
            }
        }
        else
        {
            // Default to straight movement
            tempPos.y -= speed * Time.deltaTime;
        }
        pos = tempPos;
    }
}
