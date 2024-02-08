using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Utility class for managing the torch line renderer.
    /// </summary>
    public class TorchLineRenderer
    {
        /// <summary>
        /// Sets up the torch line renderer based on two specified points.
        /// </summary>
        /// <param name="lineRendererComponent">The LineRenderer component to configure.</param>
        /// <param name="startPoint">The starting point of the torch line.</param>
        /// <param name="endPoint">The ending point of the torch line.</param>
        internal static void SetupTorchLine(LineRenderer lineRendererComponent, Transform startPoint, Transform endPoint)
        {
            lineRendererComponent.enabled = true;
            lineRendererComponent.SetPosition(0, startPoint.position);
            lineRendererComponent.SetPosition(1, endPoint.position);
        }
    }
}
