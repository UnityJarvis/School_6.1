using UnityEngine;

public class Lesson6 : MonoBehaviour
{
    public TESTINGCOLLISION spotLightCollider;
    public Light spotLight;
    void Start()
    {
        spotLightCollider = GetComponentInChildren<TESTINGCOLLISION>();
        spotLight = spotLightCollider.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        
        
        if ( spotLightCollider.triggerStatus == "Detecter Entered" )
        {
            Debug.Log("ENTEREDDDD");
            spotLight.innerSpotAngle = 30;
        }
        if ( spotLightCollider.triggerStatus == "Detecter Exited")
        {
            Debug.Log("EXITEDDD");
            spotLight.innerSpotAngle = 0;
        }
        
    }
}
