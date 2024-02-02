using UnityEngine;

public class ClassroomDoorOpener : MonoBehaviour
{
    public Animator doorAnimator;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorAnimator.Play("DoorOpen");
            Debug.Log("Door Opened");
        }
    }
    void OnTriggerExit(Collider other)
    {
        doorAnimator.Play("DoorClose");
        Debug.Log("Door Closed");
    }
}
