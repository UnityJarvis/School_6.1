using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OneSidedMirrorController : MonoBehaviour
{
    public Material roomMirrorMaterial;
    public Slider propsLightIntensitySlider;
    public Light propsRoomLight;

    [Space(10)]
    public Slider playerLightIntensitySlider;
    public Light playerRoomLight;
    public Material torchFrontGlass;

    /// <summary>
    /// Sets the initial alpha value of the room mirror material.
    /// </summary>
    private void Awake()
    {
        SetRoomMirrorMaterialAlpha(0f);
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Updates the room mirror material alpha and props room light intensity based on the props light intensity slider.
    /// </summary>
    public void UpdatePropsLightIntensity()
    {
        float propsLightIntensity = propsLightIntensitySlider.value;
        SetRoomMirrorMaterialAlpha(propsLightIntensity);
        SetPropsRoomLightIntensity(propsLightIntensity);
    }

    /// <summary>
    /// Updates the player room light intensity and torch front glass emission based on the player light intensity slider.
    /// </summary>
    public void UpdatePlayerLightIntensity()
    {
        float playerLightIntensity = playerLightIntensitySlider.value;
        SetPlayerRoomLightIntensity(playerLightIntensity);
        SetTorchFrontGlassEmission(playerLightIntensity);
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
    /// Sets the intensity of the props room light.
    /// </summary>
    /// <param name="intensity">The intensity value to set.</param>
    private void SetPropsRoomLightIntensity(float intensity)
    {
        propsRoomLight.intensity = 1f - intensity;
    }

    /// <summary>
    /// Sets the intensity of the player room light.
    /// </summary>
    /// <param name="intensity">The intensity value to set.</param>
    private void SetPlayerRoomLightIntensity(float intensity)
    {
        playerRoomLight.intensity = intensity;
    }

    /// <summary>
    /// Sets the emission color of the torch front glass material.
    /// </summary>
    /// <param name="emissionIntensity">The emission intensity value to set.</param>
    private void SetTorchFrontGlassEmission(float emissionIntensity)
    {
        torchFrontGlass.SetColor("_EmissionColor", new Color(emissionIntensity, emissionIntensity, emissionIntensity));
    }
}
