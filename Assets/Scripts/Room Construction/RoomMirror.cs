using UnityEngine;
using UnityEngine.SceneManagement;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Controls the functionality for Lesson 2, such as loading the inner room scene.
    /// </summary>
    public class RoomMirror : MonoBehaviour
    {
        /// <summary>
        /// The button used to trigger the action for Lesson 2.
        /// </summary>
        private BNG.Button lessonButton;

        /// <summary>
        /// The name of the inner room scene to load.
        /// </summary>
        public string innerRoomSceneName;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        private void Start()
        {
            // Subscribe to the onButtonDown event of the lessonButton to load the inner room scene.
            lessonButton = GetComponentInChildren<BNG.Button>();
            if(lessonButton != null )
            {
                lessonButton.onButtonDown.AddListener(() => RoomSceneLoader(innerRoomSceneName));
            }
        }
        private void RoomSceneLoader(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
