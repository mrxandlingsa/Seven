using UnityEngine;

namespace CustomPlayerController
{
    public class CustomMouseInput : MonoBehaviour
    {
        public bool IsLeftMouseClicked()
        {
            return Input.GetMouseButton(0);
        }
    }
}