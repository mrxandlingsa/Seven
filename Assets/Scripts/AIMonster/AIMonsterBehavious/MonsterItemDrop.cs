using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPlayerController;
using AIMonster;
using Item;
// 怪物死后的模型并不会消失，怪物的AI用FSM 写，其中保存怪物的当前状态，如果AI的状态为死亡，则掉落物品
public class MonsterItemDrop : MonoBehaviour
{
    public MonsterFSM monsterFSM;
    private GameObject Player;
    private 
    enum MonsterStatus  {dead,walk,patrol,chase};
    private AIMonsterReward aIMonsterReward;
    private CustomCharacterInput customCharacterInput;

    private Collider monstercollider;
    // 获取怪物的奖励脚本
    private AIMonsterReward animonsterreward;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("player")[1];
        customCharacterInput = Player.GetComponent<CustomCharacterInput>();
        monstercollider = this.GetComponent<Collider>();
        aIMonsterReward = this.GetComponent<AIMonsterReward>();
        if(customCharacterInput == null)
        {
            Debug.LogError("玩家物体未挂载脚本");
        }
    }

    // Update is called once per frame
    // 检测玩家是否输入F键,死亡后物体的碰撞体依然存在
    void Update()
    {
        
    }
    void OnCollisionStay(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player" && customCharacterInput.IsPickupKeypressed())
        {
            aIMonsterReward.SetIsPlayerGetItem();
            List<ItemBase> reward_list = aIMonsterReward.GetRewardList();
            // 玩家的背包单例添加
            if(reward_list.Count == 1)
            {
                BagItemManager.instance.AddItemSingle(reward_list[0]);
            }
            else
            {
                 BagItemManager.instance.AddItemMultiply(reward_list);
            }
            
        }
    }
}
    
