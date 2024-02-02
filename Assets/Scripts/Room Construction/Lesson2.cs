using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_2
{
    public class Lesson2 : MonoBehaviour
    {
        public BNG.Button innerButton;
        public string innerRoomSceneName;
        private void Start()
        {
            innerButton.onButtonDown.AddListener(() => PlayerTeleporter.RoomSceneLoader(innerRoomSceneName));
        }
    }
}
