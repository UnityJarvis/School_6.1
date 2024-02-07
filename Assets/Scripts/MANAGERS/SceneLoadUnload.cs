using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles scene loading and unloading functionality.
/// </summary>
public class SceneLoadUnload : MonoBehaviour
{
    /// <summary>
    /// Loads the specified scene asynchronously.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void SceneLoading(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// Unloads the specified scene asynchronously.
    /// </summary>
    /// <param name="sceneName">The name of the scene to unload.</param>
    public void SceneUnloading(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
