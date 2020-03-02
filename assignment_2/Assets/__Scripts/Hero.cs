using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;
    [Header("Set In Inspector")]
    public float speed = 10;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Set Dynamically")]
    public float shieldLevel = 1;
    
    private GameObject lastTriggerGo = null;

    // Singleton to prevent multiple instances of the player object
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        } else
        {
            Debug.Log("Attempted to assign second Hero.");
        }
    }

    void Update()
    {
        // Get user input
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // Apply x and y movement based on user input
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;

        // Set the position of the game object to the position
        transform.position = pos;

        // Apply a rotation to the game object to show roll and pitch of the object
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // Get the game object that we collided with
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        // Check if the colided game object is the same one
        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        // If the game object we colided with is an enemy, destroy the enemy and 
        // destroy the ship
        if (go.tag == "Enemy")
        {
            Destroy(go);
            Destroy(gameObject);
        }
    }
}
