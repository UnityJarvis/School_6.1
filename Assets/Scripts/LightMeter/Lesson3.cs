using InuCom.SchoolVR.physics.LightAndMatter.lesson_3;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{
    LineRenderer torchLineRenderer;
    public Transform p1, p2;
    public TMPro.TextMeshPro luxMeterText,detector3DText;
    private void Start()
    {
        torchLineRenderer = GetComponentInChildren<LineRenderer>();
        if (torchLineRenderer != null )
        {
            torchLineRenderer.SetPosition(0, p1.position);
            torchLineRenderer.SetPosition(1, p2.position);
        }
    }
    private void FixedUpdate()
    {
        detector3DText.text = LuxMeter.LuxMeterReading(p1, luxMeterText).text;
    }
}
