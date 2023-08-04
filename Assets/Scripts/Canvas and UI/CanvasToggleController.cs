using UnityEngine;
public class CanvasToggleController : MonoBehaviour
{
    public Transform canvas, handPoseTransform;
    public float worldScale, handScale;

    Vector3 worldPos,handPose;
    private void Awake()
    {
        worldPos = canvas.position;
        
        worldScale = canvas.localScale.x;
        handScale = worldScale / 15f;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || BNG.InputBridge.Instance.AButton)
        {

            ToggleCanvasPositions.Toggling(canvas, worldPos,worldScale,null);
            //canvas.SetParent(null, false);
        }

        if (Input.GetKey(KeyCode.G) || BNG.InputBridge.Instance.BButton)
        {
            handPose = handPoseTransform.position;
            ToggleCanvasPositions.Toggling(canvas, handPose, handScale, handPoseTransform);
            //canvas.SetParent(handPoseTransform,false);
        }
    }
}
