using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform targetObject;
    public float xOffset = 0f;

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null)
        {
            // Copy rotation
            transform.rotation = targetObject.rotation;

            // Copy position with an offset along the x-axis
            Vector3 targetPosition = targetObject.position;
            targetPosition.x += xOffset;
            transform.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
    }
}
