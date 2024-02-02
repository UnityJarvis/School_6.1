#region
/// copyright (c) iNucom. All rights reserved.
#endregion

using BNG;
using UnityEngine;

public class GrabTutorial : MonoBehaviour
{
    public GameObject buttonToActivateForDoorOpening;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Snap")
        {
           // other.transform.SetParent(this.transform);
            other.transform.position =this.transform.position;
            other.transform.rotation = this.transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            other.gameObject.GetComponent<Grabbable>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;

            buttonToActivateForDoorOpening.SetActive(true);
        }
    }
}