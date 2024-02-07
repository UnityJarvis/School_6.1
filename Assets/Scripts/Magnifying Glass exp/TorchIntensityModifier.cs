using UnityEngine;

namespace InuCom.SchoolVR.physics.MagnifyingGlass
{
    /// <summary>
    /// Provides functionality to modify the intensity of a torch spotlight.
    /// </summary>
    public class TorchIntensityModifier : MonoBehaviour
    {
        /// <summary>
        /// Changes the inner spot angle of the provided torch spotlight.
        /// </summary>
        /// <param name="torchSpotLight">The spotlight whose inner spot angle needs to be changed.</param>
        /// <param name="angle">The new inner spot angle value.</param>
        public static void SpotLightIntensityChanger(Light torchSpotLight, float angle)
        {
            torchSpotLight.innerSpotAngle = angle;
        }
    }
}
