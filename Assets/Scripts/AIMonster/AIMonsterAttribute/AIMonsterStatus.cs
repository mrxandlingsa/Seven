
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
/**
此类为MonsterAI的状态类，例如：如果遭遇的类似：流血，灼烧技能可扣血血量，如破甲之类，防御力减少，元素攻击--> 减血
 */
 /// 单个状态
public class SingleMonsterStatus
{
    public float last_time;
    public float last_time_attribute;
    private EnumClass.MonsterStatus monster_status;
}
public class AIMonsterStatus:MonoBehaviour
{
    // 要不要对这个进行这个限定，设置最高承受的状态个数
    private List<SingleMonsterStatus> current_monster_status_list;

    // 
    public void AddAIMonsterStatus(SingleMonsterStatus single_monster_status)
    {
        current_monster_status_list.Add(single_monster_status);
    }

    public void RemoveAIMnsterStatus(SingleMonsterStatus single_monster_status)
    {
        if(current_monster_status_list.Count != 0)
        {
            current_monster_status_list.Remove(single_monster_status);
        }
    }

    public List<SingleMonsterStatus> GetCurrentMonsterStatusList()
    {
        return current_monster_status_list;
    }

    

}




