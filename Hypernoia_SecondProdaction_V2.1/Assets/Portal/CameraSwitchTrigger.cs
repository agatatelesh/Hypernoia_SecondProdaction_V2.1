using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{   public Camera playerCamera;
    public Camera portalCamera;

    public bool isSwitched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isSwitched)
        {
            Debug.Log("Player collided with trigger object. Switching camera positions...");
            SwitchCameraPositions();
        }
    }

    private void SwitchCameraPositions()
    {
        // Get the current positions and rotations
        Vector3 playerPosition = playerCamera.transform.localPosition;
        Vector3 portalPosition = portalCamera.transform.localPosition;
        Quaternion playerRotation = playerCamera.transform.localRotation;
        Quaternion portalRotation = portalCamera.transform.localRotation;

        // Switch the positions and rotations
        playerCamera.transform.localPosition = portalPosition;
        playerCamera.transform.localRotation = portalRotation;
        portalCamera.transform.localPosition = playerPosition;
        portalCamera.transform.localRotation = playerRotation;

        // Update the switch state
        isSwitched = true;
    }
}
