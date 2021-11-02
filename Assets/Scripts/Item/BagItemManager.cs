using System.Collections;
using System.Collections.Generic;
using ServerGuilt;
using UnityEngine;

namespace Item
{
    // 玩家当前所拥有的全部物品
    public class BagItemManager : MonoBehaviour
    {
        public static BagItemManager instance;
        
        private  List<ItemBase> item_list = new  List<ItemBase>();
        // key-->物品的类型  value--> 物品的数量 
        
        private Dictionary<string, int> player_data_dic = new Dictionary<string, int>();
        
        public static BagItemManager GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (instance == null)
            {
                instance = new BagItemManager();
            }
            return instance;
        }
        
        //todo:
        private BagItemManager()
        {
            // 读取玩家数据的XML
            // 依据player_data_dic 的key 值进行在 物品的配置里寻找
        }

        // 获得/添加物品
        public void AddItemSingle(ItemBase item_base)
        {
            item_list.Add(item_base);
        }
        public void AddItemMultiply(List<ItemBase> itembase_list)
        {
            for(int i =0;i<itembase_list.Count;i++)
            {
                item_list.Add(itembase_list[i]);
            }
        }

        // 移除物品一次只能一个物品，就不用多个物品了
        public void RemoveItemSingle(ItemBase item_base)
        {
            if(item_list.Contains(item_base) == false)
            {
                Debug.LogError("");
            }
        }

    }
}