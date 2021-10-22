using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 起始页面的UI
/// </summary>
/// 
public class InitUiScript : UIBasePanel
{
    // 默认跳转为加载的界面
    public void StartGame()
    {
        // 切换场景  加载的场景
        InitManager();
        SceneLoadManager.Instance.SetCurrentSceneName("LoadScene");
        SceneManager.LoadScene(SceneLoadManager.Instance.GetCurrentSceneName());
    }
    
    public void ContinueGame()
    {
        
        
    } 
    public void ExitGame()
    {
        
        
    }
    
    // 点击按钮后进行所有manager的初始话
    public void InitManager()
    {
        SceneLoadManager.Instance.Init();
    }


}
