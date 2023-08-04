using BNG;
using UnityEngine;

namespace InuCom.SchoolVR.physics
{
    public class ExperimentSelector : MonoBehaviour
    {
        public GameObject[] expeiments;
        internal static int currentExp { get; set; }
        private void Start()
        {
            currentExp = -1;
        }

        private void Update()
        {
            switch(currentExp)
            {
                case 0:
                expeiments[0].SetActive(true);
                expeiments[1].SetActive(false);
                expeiments[2].SetActive(false);
                expeiments[3].SetActive(false);
                break;
                case 1:
                expeiments[0].SetActive(false);
                expeiments[1].SetActive(true);
                expeiments[2].SetActive(false);
                expeiments[3].SetActive(false);
                break;
                case 2:
                expeiments[0].SetActive(false);
                expeiments[1].SetActive(false);
                expeiments[2].SetActive(true);
                expeiments[3].SetActive(false);
                break;
                case 3:
                expeiments[0].SetActive(false);
                expeiments[1].SetActive(false);
                expeiments[2].SetActive(false);
                expeiments[3].SetActive(true);
                break;

                default:
                    expeiments[0].SetActive(false);
                    expeiments[1].SetActive(false);
                    expeiments[2].SetActive(false);
                    expeiments[3].SetActive(false);
                    currentExp = 0;
                    break;
            }

            if(InputBridge.Instance.AButtonDown)
            {
                currentExp ++;
            }
            if(InputBridge.Instance.BButtonDown)
            {
                currentExp --;
            }

        }
    }
}
