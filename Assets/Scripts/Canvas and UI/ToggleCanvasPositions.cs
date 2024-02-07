using UnityEngine;

/// <summary>
/// Utility class for toggling the position and scale of a GameObject.
/// </summary>
public class ToggleCanvasPositions
{
    /// <summary>
    /// Toggles the position, scale, and parent of the specified GameObject.
    /// </summary>
    /// <param name="gameObject">The GameObject to be toggled.</param>
    /// <param name="finalPos">The final position for the GameObject.</param>
    /// <param name="scale">The scale factor for the GameObject.</param>
    /// <param name="parentTransform">The parent transform for the GameObject.</param>
    public static void Toggling(Transform gameObject, Vector3 finalPos, float scale, Transform parentTransform)
    {
        gameObject.position = finalPos;
        gameObject.localScale = new Vector3(scale, scale, scale);
        gameObject.SetParent(parentTransform, false);
    }
}
