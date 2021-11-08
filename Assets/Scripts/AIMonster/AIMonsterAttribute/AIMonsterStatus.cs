
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
/**
此类为MonsterAI的状态类，例如：如果遭遇的类似：流血，灼烧技能可扣血血量，如破甲之类，防御力减少，元素攻击--> 减血
 */
 /// 单个状态
public abstract  class SingleMonsterStatusBase
{
    private int last_time;
    private EnumClass.MonsterStatus monster_status;

    public SingleMonsterStatusBase(int last_time_param)
    {
        last_time = last_time_param;
    }

    public abstract void DoFuntion();

}

public class BleedStatus:SingleMonsterStatusBase
{
    public BleedStatus(int last_time):base(last_time)
    {
    }

    public override void DoFuntion()
    {
        Debug.LogError("bleed");
    }
}

public class AIMonsterStatus:MonoBehaviour
{
    // 要不要对这个进行这个限定，设置最高承受的状态个数
    private List<SingleMonsterStatusBase> current_monster_status_list;
    
    // 
    public void AddAIMonsterStatus(SingleMonsterStatusBase single_monster_status)
    {
        current_monster_status_list.Add(single_monster_status);
    }

    public void RemoveAIMnsterStatus(SingleMonsterStatusBase single_monster_status)
    {
        if(current_monster_status_list.Count != 0)
        {
            current_monster_status_list.Remove(single_monster_status);
        }
    }

    public List<SingleMonsterStatusBase> GetCurrentMonsterStatusList()
    {
        return current_monster_status_list;
    }

    

}




