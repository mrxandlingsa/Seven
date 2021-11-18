
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ServerGuilt;
/**
此类为MonsterAI的状态类，例如：如果遭遇的类似：流血，灼烧技能可扣血血量，如破甲之类，防御力减少，元素攻击--> 减血
*/
/// 单个状态
public abstract class SingleMonsterStatusBase
{
    public float last_time;
    public string status_name;
    //该属性的持续时间
    public float status_attribute_time;
    public SingleMonsterStatusBase()
    {
    }

    public abstract void DoFuntion();


}

public class BleedStatus:SingleMonsterStatusBase
{
    public BleedStatus(int last_time):base()
    {
        base.status_name = "Bleed";
    }

    public override void DoFuntion()
    {
        Debug.LogError("bleed");
    }
}

public class MadStatus:SingleMonsterStatusBase
{
    public MadStatus(int last_time):base()
    {
        base.status_name = "Mad";
    }

    public override void DoFuntion()
    {
        Debug.LogError("mad");
    }
}

public class FireHurtStatus:SingleMonsterStatus
{


}


public class SingleMonsterStatus
{
    public float last_time;
    public float last_time_attribute;
    private EnumClass.MonsterStatus monster_status;
}






[System.Serializable]
public class AIMonsterStatus:MonoBehaviour
{
    // 要不要对这个进行这个限定，设置最高承受的状态个数
    private List<SingleMonsterStatusBase> current_monster_status_list;
    public event Action<string,int> status_event;

    private void Awake()
    {
        current_monster_status_list = new List<SingleMonsterStatusBase>();
    }

    public void AddAIMonsterStatus(SingleMonsterStatusBase single_monster_status)
    {
        string status_name = single_monster_status.status_name;
        current_monster_status_list.Add(single_monster_status);
        status_event?.Invoke(status_name,1);
    }
    
    public void RemoveAIMnsterStatus(SingleMonsterStatusBase single_monster_status)
    {
        string status_str= single_monster_status.status_name;
        if(current_monster_status_list.Count != 0)
        {
            
            current_monster_status_list.Remove(single_monster_status);
            status_event?.Invoke(status_str,2);
        }
    }

    public List<SingleMonsterStatusBase> GetCurrentMonsterStatusList()
    {
        return current_monster_status_list;
    }
       
}




