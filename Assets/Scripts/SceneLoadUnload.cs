
using BNG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadUnload : MonoBehaviour
{
    public void SceneLoading(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void SceneUnloading(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
