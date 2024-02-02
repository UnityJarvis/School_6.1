using UnityEngine;

public class VideoPlayerRenderTexture : MonoBehaviour
{
    public RenderTexture rtt;
    void Awake()
    {
        RenderTextureRelease(rtt);
    }
    public void RenderTextureRelease(RenderTexture rt)
    {
        rt.Release();
    }
    public void RenderTextureCreate(RenderTexture rt)
    {
        rt.Create();
    }
}
