using UnityEngine;
using BNG;

namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_4
{
    public class MirrorConstructionValidator : MonoBehaviour
    {
        internal static void MirrorValidation(SnapZone snapPoint,Grabbable glassGrabbale,GameObject MirrorCamRenderer)
        {
            if(snapPoint.HeldItem != null)
            {
                glassGrabbale.enabled = true;
                MirrorCamRenderer.SetActive(true);
            }   
        }
    }
}
