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
}
