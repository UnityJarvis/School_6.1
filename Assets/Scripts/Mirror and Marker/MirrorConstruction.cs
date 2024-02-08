using BNG;
using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Manages the Lesson 4 VR experience related to mirrors and reflection.
    /// </summary>
    public class MirrorConstruction : MonoBehaviour
    {
        /// <summary>
        /// The paint game object used in the lesson.
        /// </summary>
        public GameObject paintGameobject;

        /// <summary>
        /// The grabbable for the silver material.
        /// </summary>
        public Grabbable silverGrabbale;

        /// <summary>
        /// The snap zone for placing objects.
        /// </summary>
        public SnapZone snapPoint;

        /// <summary>
        /// The grabbable for the glass material.
        /// </summary>
        public Grabbable glassGrabbale;

        /// <summary>
        /// The mirror camera renderer object.
        /// </summary>
        public GameObject MirrorCamRenderer;

        /// <summary>
        /// Singleton instance of the Lesson4 class.
        /// </summary>
        public static MirrorConstruction instance;

        void Start()
        {
            instance = this;
        }

        private void Update()
        {
            // Check and validate mirror construction in the VR lesson.
            MirrorValidation(snapPoint, glassGrabbale, MirrorCamRenderer);
        }
        private void MirrorValidation(SnapZone snapPoint, Grabbable glassGrabbale, GameObject MirrorCamRenderer)
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
