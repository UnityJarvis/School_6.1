using UnityEngine;
public class TestInputScript : MonoBehaviour
{
    public Transform canvas, handPoseTransform;
    public float worldScale, handScale;

    Vector3 worldPos,handPose;
    private void Awake()
    {
        worldPos = canvas.position;
        
        worldScale = canvas.localScale.x;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || BNG.InputBridge.Instance.AButton)
        {

            //ToggleCanvasPositions.Toggling(canvas, worldPos,worldScale);
            canvas.SetParent(null, false);
        }

        if (Input.GetKeyDown(KeyCode.G) || BNG.InputBridge.Instance.BButton)
        {
            handPose = handPoseTransform.position;
            //ToggleCanvasPositions.Toggling(canvas, handPose, handScale);
            canvas.SetParent(handPoseTransform,false);
        }
    }
}
