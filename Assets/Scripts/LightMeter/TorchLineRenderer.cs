using UnityEngine;

namespace InuCom.SchoolVR.physics
{
    namespace LightAndMatter.lesson_3
    {
        public class TorchLineRenderer
        {
            internal static void torchRenderer(LineRenderer lineRendererComponent, Transform p1, Transform p2)
            {
                lineRendererComponent.enabled = true;
                lineRendererComponent.SetPosition(0, p1.position);
                lineRendererComponent.SetPosition(1, p2.position);
            }
        }
    }
}

