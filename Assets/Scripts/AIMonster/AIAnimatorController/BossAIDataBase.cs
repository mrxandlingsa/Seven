using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIDataBase:MonoBehaviour
{
    // 数据直接在prefab中直接调吧
    [SerializeField]
    private int current_boss_health;
    [SerializeField]
    private int max_boss_health;
    [SerializeField]
    private int boss_armour_type;
    private void Start() {
        current_boss_health = max_boss_health;
    }

    public void IncreaseHealth(int addition)
    {
        if(addition +current_boss_health >= current_boss_health)
        {
            current_boss_health = max_boss_health;
        }
    }
    public void DecreaseHealth(int decrement)
    {
        if(current_boss_health -decrement <0)
        {
            current_boss_health = 0;
        }
    }


}
