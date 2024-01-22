
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
       // Reference to the Timeline asset
    public PlayableDirector timeline;

    // Variable to track whether the player is inside the trigger
    private bool playerInsideTrigger = false;

    // Variable to store the timeline's current time when paused
    private double pausedTime;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger, start or resume the timeline
            playerInsideTrigger = true;

            if (timeline.state != PlayState.Playing)
            {
                // If the timeline is not already playing, start it
                timeline.Play();
            }
            else
            {
                // If the timeline is already playing, resume from where it was paused
                timeline.time = pausedTime;
            }

            Debug.Log("PlayerCollidetWith a Zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger, pause the timeline
            playerInsideTrigger = false;
            pausedTime = timeline.time; // Save the current time for resuming later
            timeline.Pause();
            Debug.Log("Player Out Of Zone a Zone");
        }
    }

    private void Update()
    {
        // Check if the player is inside the trigger
        if (playerInsideTrigger)
        {
            // If the timeline is not playing, start it
            if (timeline.state != PlayState.Playing)
            {
                timeline.Play();
            }
        }
        else
        {
            // If the player is outside the trigger, pause the timeline
            if (timeline.state == PlayState.Playing)
            {
                pausedTime = timeline.time; // Save the current time for resuming later
                timeline.Pause();
            }
        }
    }

}
