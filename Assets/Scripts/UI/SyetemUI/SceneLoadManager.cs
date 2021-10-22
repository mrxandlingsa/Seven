using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadManager:Single<SceneLoadManager>
{
     
    public string current_scene_name = "";
    
    public void SetCurrentSceneName(string current_name)
    {
        current_scene_name = current_name;
    }
    
    public string GetCurrentSceneName()
    {
        return current_scene_name;
    }



}
