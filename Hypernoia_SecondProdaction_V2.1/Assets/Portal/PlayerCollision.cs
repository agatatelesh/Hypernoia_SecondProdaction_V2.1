using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ObjectFollower objectFollower; // Assign the ObjectFollower script in the Unity Inspector
    public float newOffsetOnCollision = 10f; // Set this to your desired amount

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered with: " + other.gameObject.name);

        // Check if the ObjectFollower script is assigned
        if (objectFollower != null)
        {
            // Set the xOffset to the specified amount when a collision occurs
            objectFollower.xOffset = newOffsetOnCollision;
        }
    }

    /*
     private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered with: " + other.gameObject.name);
    }*/
}
