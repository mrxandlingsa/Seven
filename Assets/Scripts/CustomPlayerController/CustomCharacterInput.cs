using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomPlayerController
{
    public abstract class CustomCharacterInput : MonoBehaviour
    {
        public abstract float GetHorizontalMovementInput();
        public abstract float GetVerticalMovementInput();

        public abstract bool IsJumpKeyPressed();
    }
}