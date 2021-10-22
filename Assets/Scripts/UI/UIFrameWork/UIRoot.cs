using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
public class UIRoot : MonoBehaviour
{
    void Awake()
    {
        //在游戏开始时加载MainMenuPanel
        UIManager.Instance.PushPanel(EnumClass.UIPanelType.UiInitPanel);
    }
}

