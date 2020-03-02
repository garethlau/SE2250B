using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{

    [Header("Set In Inspector")]
    public float fireRate = 0.3f;
    public float health = 10;
    public int score = 100;

    [Header("Set Dynamically")]
    private BoundsCheck boundsCheck;

    // Get the BoundsCheck component
    private void Awake()
    {
        boundsCheck = GetComponent<BoundsCheck>();
    }

    public void CheckOutOfBounds()
    {
        if (boundsCheck != null && !boundsCheck.isOnScreen)
        {
            Destroy(gameObject);
        }
    }
}
