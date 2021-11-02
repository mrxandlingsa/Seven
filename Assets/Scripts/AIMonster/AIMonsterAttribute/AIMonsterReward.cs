using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomPlayerController;
using Item;
namespace AIMonster
{
    public class AIMonsterReward
    {
        private bool IsPlayerGetItem; 
        private List<ItemBase> monster_reward_list;
        public AIMonsterReward()
        {
            IsPlayerGetItem = false;
            //怪物死亡掉落的奖励就读XML表
            //todo:
        }
        public void SetIsPlayerGetItem()
        {
            IsPlayerGetItem = true;
        }
        public List<ItemBase>  GetRewardList()
        {
            return monster_reward_list;
        }
    }
}