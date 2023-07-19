using UnityEngine;

namespace InuCom.SchoolVR.physics.LightAndMatter.lesson_2
{
    public class Lesson2 : MonoBehaviour
    {
        public BNG.Button innerButton;
        public int innerRoomSceneIndex;
        private void Start()
        {
            innerButton.onButtonDown.AddListener(() => PlayerTeleporter.RoomSceneLoader(innerRoomSceneIndex));
        }
    }
}
