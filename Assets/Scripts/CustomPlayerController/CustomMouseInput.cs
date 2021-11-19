using UnityEngine;

namespace CustomPlayerController
{
    public class CustomMouseInput : MonoBehaviour
    {
        public KeyCode DashKey = KeyCode.LeftShift;
        public bool IsLeftMouseClicked()
        {
            return Input.GetMouseButton(0);
        }
        
        public bool IsLeftShiftPressed()
        {
            return Input.GetKey(DashKey);
        }
    }
}