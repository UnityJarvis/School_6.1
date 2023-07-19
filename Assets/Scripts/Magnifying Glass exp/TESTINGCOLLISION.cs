using UnityEngine;

public class TESTINGCOLLISION : MonoBehaviour
{
    public string triggerStatus { get; private set; }
    private void OnTriggerEnter(Collider other){triggerStatus = other.tag + " Entered";}
    private void OnTriggerExit(Collider other){triggerStatus = other.tag + " Exited";}
}
