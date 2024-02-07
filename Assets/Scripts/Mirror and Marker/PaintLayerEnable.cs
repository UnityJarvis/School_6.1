using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// PaintLayerEnable class responsible for enabling the paint layer when the silver marker exits.
    /// </summary>
    public class PaintLayerEnable : MonoBehaviour
    {
        private int exitCount = 0;
        public GameObject paintLineRendererRoot;

        /// <summary>
        /// Triggered when another collider exits the trigger.
        /// </summary>
        /// <param name="other">The other Collider involved in this collision.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Silver")
            {
                exitCount++;

                if (exitCount >= 10)
                {
                    paintLineRendererRoot = GameObject.FindGameObjectWithTag("PaintBrushLineRendererRoot");

                    if (paintLineRendererRoot != null)
                    {
                        ActivatePaintLayer(MirrorConstruction.instance.paintGameobject, paintLineRendererRoot);
                    }
                }
            }
        }

        /// <summary>
        /// Activate the paint layer and enable the necessary components.
        /// </summary>
        /// <param name="paint">The paint GameObject to activate.</param>
        /// <param name="paintLineRendererRoot">The root GameObject for the paint line renderer.</param>
        internal static void ActivatePaintLayer(GameObject paint, GameObject paintLineRendererRoot)
        {
            paint.SetActive(true);
            MirrorConstruction.instance.silverGrabbale.enabled = true;
            paintLineRendererRoot.SetActive(false);
        }
    }
}



//Attach this to tip of Marker having box collider