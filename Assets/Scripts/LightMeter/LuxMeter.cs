using UnityEngine;

namespace InuCom.SchoolVR.physics
{
    namespace LightAndMatter.lesson_3
    {
        public class LuxMeter
        {
            internal static TMPro.TextMeshPro LuxMeterReading(Transform rayOrigin, TMPro.TextMeshPro luxMeterReading3DText)
            {
                RaycastHit hit;
                if (Physics.Raycast(rayOrigin.position, rayOrigin.transform.forward,out hit,10,11))
                {
                    luxMeterReading3DText.text = ((1/hit.distance) * 100).ToString("00") + " LUX";
                }
                Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward, Color.red);
                return luxMeterReading3DText;
            }
        }
    }
}
