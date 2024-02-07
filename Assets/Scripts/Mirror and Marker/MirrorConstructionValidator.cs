using UnityEngine;
using BNG;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Validates and manages mirror construction in the VR lesson.
    /// </summary>
    public class MirrorConstructionValidator : MonoBehaviour
    {
        /// <summary>
        /// Validates mirror construction based on the provided parameters.
        /// </summary>
        /// <param name="snapPoint">The snap zone for placing objects.</param>
        /// <param name="glassGrabbale">The grabbable for the glass material.</param>
        /// <param name="MirrorCamRenderer">The mirror camera renderer object.</param>
        internal static void MirrorValidation(SnapZone snapPoint, Grabbable glassGrabbale, GameObject MirrorCamRenderer)
        {
            // Check if an item is held in the snap zone.
            if (snapPoint.HeldItem != null)
            {
                // Enable the grabbable for glass material.
                glassGrabbale.enabled = true;

                // Activate the mirror camera renderer.
                MirrorCamRenderer.SetActive(true);
            }
        }
    }
}
