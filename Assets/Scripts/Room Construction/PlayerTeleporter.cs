using UnityEngine;
using UnityEngine.SceneManagement;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Handles teleporting the player to different scenes.
    /// </summary>
    public class PlayerTeleporter : MonoBehaviour
    {
        /// <summary>
        /// Loads the specified room scene asynchronously.
        /// </summary>
        /// <param name="sceneName">The name of the scene to load.</param>
        internal static void RoomSceneLoader(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
