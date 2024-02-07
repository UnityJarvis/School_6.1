using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter
{
    /// <summary>
    /// Controls the functionality for Lesson 2, such as loading the inner room scene.
    /// </summary>
    public class LightMeter : MonoBehaviour
    {
        /// <summary>
        /// The button used to trigger the action for Lesson 2.
        /// </summary>
        public BNG.Button lessonButton;

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
            lessonButton.onButtonDown.AddListener(() => PlayerTeleporter.RoomSceneLoader(innerRoomSceneName));
        }
    }
}
