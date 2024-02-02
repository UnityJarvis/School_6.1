using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsideRoomFunctionalityController : MonoBehaviour
{
    public Material roomMirrorMaterial;
    public Slider propsSlider;
    public Light propsRoomLight;

    [Space(10)]
    public Slider playerSlider;
    public Light playerRoomLight;
    public Material torchFrontGlass;

    private void Awake()
    {
        roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, 0f);
    }

    public void Deport(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void lightIntensity()
    {
        roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, propsSlider.value); // Mirror Material Alpha
        propsRoomLight.intensity = (1f - propsSlider.value);
    }
    public void playerLightIntensity()
    {
        playerRoomLight.intensity = playerSlider.value;
        torchFrontGlass.SetColor("_EmissionColor", new Color(playerSlider.value * 255, playerSlider.value * 255, playerSlider.value * 255));
    }
}

