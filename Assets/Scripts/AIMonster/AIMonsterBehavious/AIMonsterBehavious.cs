using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerGuilt;
/**
 是否需要将在实时进行改变的行为全部放在同一个类中，此类必须继承monobehaviour
 */
public class AIMonsterBehavious : MonoBehaviour
{
    private AIMonsterStatus aimonsterStatus;
    // 目前先把monster的状态行为放在这里面
    void Start()
    {
        aimonsterStatus = this.GetComponent<AIMonsterStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 行为状态的具体执行
    private void ExecuteDefiniteFunction(EnumClass.MonsterStatus sta)
    {
        switch(sta)
        {
            case EnumClass.MonsterStatus.Mad:
                break;
            case EnumClass.MonsterStatus.Bloody:

                break;
            case EnumClass.MonsterStatus.ArmorPenetration:
                
                break;
        }
    }

}
