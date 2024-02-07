using UnityEngine;

/// <summary>
/// Manages the lifecycle of a RenderTexture for video playback.
/// </summary>
public class VideoPlayerRenderTexture : MonoBehaviour
{
    /// <summary>
    /// The RenderTexture used for video rendering.
    /// </summary>
    public RenderTexture videoRenderTexture;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        ReleaseRenderTexture(videoRenderTexture);
    }

    /// <summary>
    /// Releases the given RenderTexture.
    /// </summary>
    /// <param name="rt">The RenderTexture to release.</param>
    public void ReleaseRenderTexture(RenderTexture rt)
    {
        if (rt != null)
        {
            rt.Release();
        }
    }

    /// <summary>
    /// Creates the given RenderTexture.
    /// </summary>
    /// <param name="rt">The RenderTexture to create.</param>
    public void CreateRenderTexture(RenderTexture rt)
    {
        if (rt != null)
        {
            rt.Create();
        }
    }
}
