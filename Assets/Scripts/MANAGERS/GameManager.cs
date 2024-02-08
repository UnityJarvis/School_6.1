using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the overall game functionality, including debugging information and scene management.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Gets the singleton instance of the GameManager.
    /// </summary>
    public static GameManager Instance { get; private set; }

    [Header("Debugging")]
    [Tooltip("Frames per second")]
    public float framesPerSecond;
    public TMPro.TMP_Text fpsText;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (fpsText != null)
        {
            UpdateFPS();
        }
    }

    /// <summary>
    /// Updates the frames per second information.
    /// </summary>
    private void UpdateFPS()
    {
        framesPerSecond = 1 / Time.unscaledDeltaTime;
        DisplayFPS();
        ToggleFPSVisibility(BNG.InputBridge.Instance.AButton);
    }

    /// <summary>
    /// Displays the frames per second on the UI.
    /// </summary>
    private void DisplayFPS()
    {
        fpsText.text = framesPerSecond.ToString("000");
    }

    /// <summary>
    /// Loads the specified level asynchronously.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void LoadLevelAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }

    #region DEBUGGING

    /// <summary>
    /// Toggles the visibility of the frames per second on the UI.
    /// </summary>
    /// <param name="status">The visibility status.</param>
    private void ToggleFPSVisibility(bool status)
    {
        fpsText.enabled = status;
    }

    #endregion
}