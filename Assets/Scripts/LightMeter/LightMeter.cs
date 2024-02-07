using UnityEngine;
using InuCom.SchoolVR.physics.LightAndMatter;

/// <summary>
/// Represents the behavior of Lesson 3, including the torch line renderer and Lux meter readings.
/// </summary>
public class LightMeter : MonoBehaviour
{
    /// <summary>
    /// Line renderer for the torch.
    /// </summary>
    private LineRenderer torchLineRenderer;

    /// <summary>
    /// Start point for the torch line.
    /// </summary>
    public Transform startPoint;

    /// <summary>
    /// End point for the torch line.
    /// </summary>
    public Transform endPoint;

    /// <summary>
    /// Text displaying Lux meter readings.
    /// </summary>
    public TMPro.TextMeshPro luxMeterText;

    /// <summary>
    /// Text displaying 3D detector information.
    /// </summary>
    public TMPro.TextMeshPro detector3DText;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        InitializeTorchLineRenderer();
    }

    /// <summary>
    /// Initializes the torch line renderer.
    /// </summary>
    private void InitializeTorchLineRenderer()
    {
        torchLineRenderer = GetComponentInChildren<LineRenderer>();

        if (torchLineRenderer != null)
        {
            torchLineRenderer.enabled = true;
            torchLineRenderer.SetPosition(0, startPoint.position);
            torchLineRenderer.SetPosition(1, endPoint.position);
        }
    }

    /// <summary>
    /// Called every fixed framerate frame.
    /// </summary>
    private void FixedUpdate()
    {
        UpdateLuxMeterReading();
    }

    /// <summary>
    /// Updates the Lux meter reading and displays the result.
    /// </summary>
    private void UpdateLuxMeterReading()
    {
        detector3DText.text = LuxMeter.LuxMeterReading(startPoint, luxMeterText).text;
    }
}
