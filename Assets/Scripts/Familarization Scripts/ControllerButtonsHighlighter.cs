using UnityEngine;

/// <summary>
/// Controls the material changes on different parts of a virtual controller.
/// </summary>
public class ControllerButtonsHighlighter : MonoBehaviour
{
    /// <summary>
    /// Material for the ABXY buttons.
    /// </summary>
    public Material abxyMat;

    /// <summary>
    /// Material for the thumbstick.
    /// </summary>
    public Material thumbstickMat;

    /// <summary>
    /// Material for the index button.
    /// </summary>
    public Material indexMat;

    /// <summary>
    /// Material for the Oculus menu button.
    /// </summary>
    public Material oculusMenuMat;

    /// <summary>
    /// Material for the menu button.
    /// </summary>
    public Material menuMat;

    /// <summary>
    /// Material for the grip button.
    /// </summary>
    public Material gripMat;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    public void Awake()
    {
        ResetMaterials();
    }

    /// <summary>
    /// Changes the color of a specified material and resets others to white.
    /// </summary>
    /// <param name="mat">The material to be changed.</param>
    public void ChangeMaterial(Material mat)
    {
        ResetMaterials();
        mat.color = Color.blue;
    }

    /// <summary>
    /// Resets the color of all materials to white.
    /// </summary>
    public void ResetMaterials()
    {
        abxyMat.color = Color.white;
        thumbstickMat.color = Color.white;
        indexMat.color = Color.white;
        oculusMenuMat.color = Color.white;
        menuMat.color = Color.white;
        gripMat.color = Color.white;
    }

    /// <summary>
    /// Called when the application is quitting.
    /// </summary>
    public void OnApplicationQuit()
    {
        ResetMaterials();
    }
}
