using BNG;
using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_4
{
    public class Lesson4 : MonoBehaviour
    {
        public GameObject paintGameobject;
        public Grabbable silverGrabbale;
        public SnapZone snapPoint;
        public Grabbable glassGrabbale;
        public GameObject MirrorCamRenderer;
        //public GameObject SilverPaint;
        //public Grabbable silverGrabbable;
        public static Lesson4 instance;
        void Start()
        {
            instance = this;
        }

        private void Update()
        {
            MirrorConstructionValidator.MirrorValidation(snapPoint, glassGrabbale,MirrorCamRenderer);
        }

    }
}

