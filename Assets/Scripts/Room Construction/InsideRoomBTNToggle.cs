using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideRoomBTNToggle : MonoBehaviour
{
    public Material roomMirrorMaterial;
    public Light propsLight, playerLight;
    bool propsLightStatus = true, playerLightStatus = true;
    private void Start()
    {
        propsLight.enabled = true;
        playerLight.enabled = true;
    }
    public void PlayerLightToggle()
    {
        playerLightStatus = !playerLightStatus;

        playerLight.enabled = playerLightStatus;
    }
    public void PropsLightToggle()
    {
        propsLightStatus = !propsLightStatus;

        propsLight.enabled = propsLightStatus;
    }
    private void Awake()
    {
        roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, 0f);
    }
    private void Update()
    {
        if(propsLightStatus == false)
        {
            roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, 1f);
        }
        if(propsLightStatus == true)
        {
            roomMirrorMaterial.color = new Color(roomMirrorMaterial.color.r, roomMirrorMaterial.color.g, roomMirrorMaterial.color.b, 0f);
        }
    }
    public void Deport(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
