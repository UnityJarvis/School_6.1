using UnityEngine;

/// <summary>
/// Controls the opening and closing of a classroom door using an Animator.
/// </summary>
public class ClassroomDoorOpener : MonoBehaviour
{
    /// <summary>
    /// The Animator component responsible for door animations.
    /// </summary>
    public Animator doorAnimator;

    /// <summary>
    /// Called when another collider enters the trigger collider.
    /// </summary>
    /// <param name="other">The Collider of the entering object.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider.
    /// </summary>
    /// <param name="other">The Collider of the exiting object.</param>
    void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

    /// <summary>
    /// Opens the door by playing the "DoorOpen" animation.
    /// </summary>
    private void OpenDoor()
    {
        doorAnimator.Play("DoorOpen");
    }

    /// <summary>
    /// Closes the door by playing the "DoorClose" animation.
    /// </summary>
    private void CloseDoor()
    {
        doorAnimator.Play("DoorClose");
    }
}
