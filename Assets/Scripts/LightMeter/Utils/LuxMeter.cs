using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Utility class for Lux meter readings.
    /// </summary>
    public class LuxMeter
    {
        /// <summary>
        /// Calculates Lux meter reading based on the ray origin and updates the text display.
        /// </summary>
        /// <param name="rayOrigin">The ray origin transform.</param>
        /// <param name="luxMeterReading3DText">The text component for Lux meter reading display.</param>
        /// <returns>The updated Lux meter reading text component.</returns>
        internal static TMPro.TextMeshPro LuxMeterReading(Transform rayOrigin, TMPro.TextMeshPro luxMeterReading3DText)
        {
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin.position, rayOrigin.transform.forward, out hit, 10, 11))
            {
                float reading = (1f / hit.distance) * 100f;
                reading = Mathf.Clamp(reading, 10f, 5000f);
                luxMeterReading3DText.text = reading.ToString("00") + " LUX";
            }

            Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward, Color.red);

            return luxMeterReading3DText;
        }
    }
}
