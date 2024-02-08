using UnityEngine;

public class SpotLightOnTrigger : MonoBehaviour
{
    private Light spotLight;

    /// <summary>
    /// Initializes the spotlight reference during Awake.
    /// </summary>
    private void Awake()
    {
        spotLight = GetComponent<Light>();
    }

    /// <summary>
    /// Handles the triggering when another collider enters the detection area.
    /// </summary>
    /// <param name="other">The collider entering the detection area.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Detecter"))
        {
            SpotLightIntensityChanger(spotLight, spotLight.spotAngle);
        }
    }

    /// <summary>
    /// Handles the triggering when another collider exits the detection area.
    /// </summary>
    /// <param name="other">The collider exiting the detection area.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Detecter"))
        {
            SpotLightIntensityChanger(spotLight, 0);
        }
    }
    void SpotLightIntensityChanger(Light torchSpotLight, float angle)
    {
        torchSpotLight.innerSpotAngle = angle;
    }
}
