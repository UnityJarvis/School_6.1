using UnityEngine;
namespace InuCom.SchoolVR.physics.MagnifyingGlass
{
    public class TorchIntensityModifier : MonoBehaviour
    {
        public static void SpotLightIntensityChanger(Light torchSpotLight,float angle)
        {
            torchSpotLight.innerSpotAngle = angle;
        }
    }
}
