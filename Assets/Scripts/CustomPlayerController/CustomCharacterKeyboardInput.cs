using UnityEngine;
using System.Collections;

namespace CustomPlayerController
{
    public class CustomCharacterKeyboardInput: CustomCharacterInput
    {
        public string horizontalInputAxis = "Horizontal";
        public string verticalInputAxis = "Vertical";
        public KeyCode jumpKey = KeyCode.Space;
        
        // 按下F键拾取
        public KeyCode PickupKey = KeyCode.F;
        public bool useRawInput = true;
        
        public override float GetHorizontalMovementInput()
        {
            if(useRawInput)
                return Input.GetAxisRaw(horizontalInputAxis);
            else
                return Input.GetAxis(horizontalInputAxis);
        }

        public override float GetVerticalMovementInput()
        {
            if(useRawInput)
                return Input.GetAxisRaw(verticalInputAxis);
            else
                return Input.GetAxis(verticalInputAxis);
        }

        public override bool IsJumpKeyPressed()
        {
            return Input.GetKey(jumpKey);
        }
        public override bool IsPickupKeypressed()
        {
            return Input.GetKey(PickupKey);
        }
        
        
        
    }
}