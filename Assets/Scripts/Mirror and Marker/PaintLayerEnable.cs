using UnityEngine;
namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_4
{
    public class PaintLayerEnable : MonoBehaviour
    {
        int i = 0;
        GameObject paintLineRendererRoot;
        private void OnTriggerExit(Collider other)
        {
            if(other.name == "Silver")
            {
                i++;
                if (i >= 10)
                {
                    paintLineRendererRoot = GameObject.FindGameObjectWithTag("PaintBrushLineRendererRoot");
                    if (paintLineRendererRoot != null )
                        ActivatePaintLayer(Lesson4.instance.paintGameobject, paintLineRendererRoot);
                }
            }
        }

        internal static void ActivatePaintLayer(GameObject paint,GameObject paintLineRendererRoot)
        {
            paint.SetActive(true);
            Lesson4.instance.silverGrabbale.enabled = true;
            paintLineRendererRoot.SetActive(false);
        }
    }
}



//Attach this to tip of Marker having box collider