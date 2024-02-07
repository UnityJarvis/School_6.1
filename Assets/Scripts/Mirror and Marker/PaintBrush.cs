using System.Collections;
using UnityEngine;
using BNG;

/// <summary>
/// PaintBrush class for drawing in VR using a brush.
/// </summary>
public class PaintBrush : GrabbableEvents
{
    public Material DrawMaterial;
    public Color DrawColor = Color.red;
    public float LineWidth = 0.02f;

    public Transform RaycastStart;
    public LayerMask DrawingLayers;

    public float RaycastLength = 0.01f;

    /// <summary>
    /// Minimum distance required from points to place drawing down.
    /// </summary>
    public float MinDrawDistance = 0.02f;
    public float ReuseTolerance = 0.001f;

    [Space(10)]
    public bool usingWorldSpace;

    bool isNewDraw = false;
    Vector3 lastDrawPoint;
    LineRenderer lineRenderer;

    // Use this to store our Marker's LineRenderers
    Transform root;
    Transform lastTransform;
    Coroutine drawRoutine = null;
    float lastLineWidth = 0;
    int renderLifeTime = 0;

    private void Update()
    {
        if (lineRenderer != null)
            lineRenderer.useWorldSpace = usingWorldSpace;
    }

    public override void OnGrab(Grabber grabber)
    {
        if (drawRoutine == null)
        {
            drawRoutine = StartCoroutine(WriteRoutine());
        }

        base.OnGrab(grabber);
    }

    public override void OnRelease()
    {
        if (drawRoutine != null)
        {
            StopCoroutine(drawRoutine);
            drawRoutine = null;
        }
        base.OnRelease();
    }

    /// <summary>
    /// Coroutine for writing routine.
    /// </summary>
    /// <returns>IEnumerator for the coroutine.</returns>
    IEnumerator WriteRoutine()
    {
        while (true)
        {
            if (Physics.Raycast(RaycastStart.position, RaycastStart.up, out RaycastHit hit, RaycastLength, DrawingLayers, QueryTriggerInteraction.Ignore))
            {
                float tipDistance = Vector3.Distance(hit.point, RaycastStart.transform.position);
                float tipPercentage = tipDistance / RaycastLength;
                Vector3 drawStart = hit.point + (-RaycastStart.up * 0.0005f);
                Quaternion drawRotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
                float lineWidth = LineWidth * (1 - tipPercentage);
                InitDraw(drawStart, drawRotation, lineWidth, DrawColor);
            }
            else
            {
                isNewDraw = true;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// Initialize the drawing based on given parameters.
    /// </summary>
    /// <param name="position">Starting position of the drawing.</param>
    /// <param name="rotation">Rotation of the drawing.</param>
    /// <param name="lineWidth">Width of the drawing line.</param>
    /// <param name="lineColor">Color of the drawing line.</param>
    void InitDraw(Vector3 position, Quaternion rotation, float lineWidth, Color lineColor)
    {
        if (isNewDraw)
        {
            lastDrawPoint = position;
            DrawPoint(lastDrawPoint, position, lineWidth, lineColor, rotation);
            isNewDraw = false;
        }
        else
        {
            float distance = Vector3.Distance(lastDrawPoint, position);
            if (distance > MinDrawDistance)
            {
                lastDrawPoint = DrawPoint(lastDrawPoint, position, lineWidth, DrawColor, rotation);
            }
        }
    }

    /// <summary>
    /// Draw a point in the drawing.
    /// </summary>
    /// <param name="lastDrawPoint">Last drawn point.</param>
    /// <param name="endPosition">End position of the drawing.</param>
    /// <param name="lineWidth">Width of the drawing line.</param>
    /// <param name="lineColor">Color of the drawing line.</param>
    /// <param name="rotation">Rotation of the drawing.</param>
    /// <returns>End position of the drawing.</returns>
    Vector3 DrawPoint(Vector3 lastDrawPoint, Vector3 endPosition, float lineWidth, Color lineColor, Quaternion rotation)
    {
        var difference = Mathf.Abs(lastLineWidth - lineWidth);
        lastLineWidth = lineWidth;
        if (difference > ReuseTolerance || renderLifeTime >= 98)
        {
            lineRenderer = null;
            renderLifeTime = 0;
        }
        else
        {
            renderLifeTime += 1;
        }
        if (isNewDraw || lineRenderer == null)
        {
            lastTransform = new GameObject().transform;
            lastTransform.name = "DrawLine";
            if (root == null)
            {
                root = new GameObject().transform;
                root.name = "MarkerLineHolder";
                root.tag = "PaintBrushLineRendererRoot";
            }
            lastTransform.parent = root;
            lastTransform.position = endPosition;
            lastTransform.rotation = rotation;
            lineRenderer = lastTransform.gameObject.AddComponent<LineRenderer>();

            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;
            var curve = new AnimationCurve();
            curve.AddKey(0, lineWidth);
            lineRenderer.widthCurve = curve;
            if (DrawMaterial)
            {
                lineRenderer.material = DrawMaterial;
            }
            lineRenderer.numCapVertices = 5;
            lineRenderer.alignment = LineAlignment.TransformZ;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, lastDrawPoint);
            lineRenderer.SetPosition(1, endPosition);
        }
        else
        {
            if (lineRenderer != null)
            {
                lineRenderer.widthMultiplier = 1;
                lineRenderer.positionCount += 1;
                var curve = lineRenderer.widthCurve;
                curve.AddKey((lineRenderer.positionCount - 1) / 100, lineWidth);
                lineRenderer.widthCurve = curve;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, endPosition);
            }
        }
        return endPosition;
    }

    /// <summary>
    /// Gizmos for drawing selected objects.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        // Show Grip Point
        Gizmos.color = Color.green;
        Gizmos.DrawLine(RaycastStart.position, RaycastStart.position + RaycastStart.up * RaycastLength);
    }
}
