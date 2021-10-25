using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomPlayerController
{
    public abstract class CustomCameraInput: MonoBehaviour
    {
        public abstract float GetHorizontalCameraInput();
        public abstract float GetVerticalCameraInput();
    }
}