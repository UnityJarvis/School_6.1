using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideRoomBTNToggle : MonoBehaviour
{
    public Material roomMirrorMaterial;
    public Light propsLight;
    public Light playerLight;

    private bool propsLightEnabled = true;
    private bool playerLightEnabled = true;

    /// <summary>
    /// Initializes the lights to be enabled when the scene starts.
    /// </summary>
    private void Start()
    {
        propsLight.enabled = propsLightEnabled;
        playerLight.enabled = playerLightEnabled;
    }

    /// <summary>
    /// Toggles the player light on and off.
    /// </summary>
    public void TogglePlayerLight()
    {
        playerLightEnabled = !playerLightEnabled;
        playerLight.enabled = playerLightEnabled;
    }

    /// <summary>
    /// Toggles the props light on and off.
    /// </summary>
    public void TogglePropsLight()
    {
        propsLightEnabled = !propsLightEnabled;
        propsLight.enabled = propsLightEnabled;

        UpdateRoomMirrorMaterial();
    }

    /// <summary>
    /// Sets the initial alpha value of the room mirror material.
    /// </summary>
    private void Awake()
    {
        SetRoomMirrorMaterialAlpha(0f);
    }

    /// <summary>
    /// Updates the room mirror material alpha based on the status of the props light.
    /// </summary>
    private void UpdateRoomMirrorMaterial()
    {
        float alpha = propsLightEnabled ? 0f : 1f;
        SetRoomMirrorMaterialAlpha(alpha);
    }

    /// <summary>
    /// Sets the alpha value of the room mirror material.
    /// </summary>
    /// <param name="alpha">The alpha value to set.</param>
    private void SetRoomMirrorMaterialAlpha(float alpha)
    {
        roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, alpha);
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
