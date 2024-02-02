using UnityEngine;
using UnityEngine.SceneManagement;

namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_2
{
    public class PlayerTeleporter : MonoBehaviour
    {
        internal static void RoomSceneLoader(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
