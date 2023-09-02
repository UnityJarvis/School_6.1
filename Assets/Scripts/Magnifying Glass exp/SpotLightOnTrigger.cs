using InuCom.SchoolVR.physics.MagnifyingGlass;
using UnityEngine;

public class SpotLightOnTrigger : MonoBehaviour
{
    Light spotLightt;
    private void Awake()
    {
        spotLightt = GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Detecter")
        {
            //TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, 0);
            TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, spotLightt.spotAngle);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Detecter")
        {
            //TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, spotLightt.spotAngle);
            TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, 0);
        }
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.tag == "Detecter")
    //     {
    //         //TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, 0);
    //         TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, spotLightt.spotAngle);
    //     }

    // }
    // private void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.tag == "Detecter")
    //     {
    //         //TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, spotLightt.spotAngle);
    //         TorchIntensityModifier.SpotLightIntensityChanger(spotLightt, 0);
    //     }
    // }
}
