using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the overall game functionality, including debugging information and scene management.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Debugging")]
    public float fps;
    public TMPro.TMP_Text fpsText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateFPS();
    }

    private void UpdateFPS()
    {
        fps = 1 / Time.unscaledDeltaTime;
        DisplayFPS();
        ToggleFPSVisibility(BNG.InputBridge.Instance.AButton);
    }

    private void DisplayFPS()
    {
        fpsText.text = fps.ToString("000");
    }

    public void LoadSceneByIndexNumber(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    #region DEBUGGING

    private void ToggleFPSVisibility(bool status)
    {
        fpsText.enabled = status;
    }

    #endregion
}
