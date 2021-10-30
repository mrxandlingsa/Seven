using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Player
{


    // 是否在此新建一个event
    // 玩家的全部数据类型就全部都写在这个类中，表象在写其他的脚本
    public class PlayerBase : MonoBehaviour
    {
        // 这个静态的类有什么属性以后在顶
        private static PlayerBase PlayerInstance;
        
        public static PlayerBase GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (PlayerInstance == null)
            {
                PlayerInstance = new PlayerBase();
            }
            return PlayerInstance;
        }
        
        
        private int PlayerMaxHealth;
        private int PlayerCurrentHealth;
        public static int PlayerMaxMagic;
        private int PlayerCurrentMagic;
        
        // 非生命值类的属性
        // 攻击力
        
        
        // 构造函数
        
        public PlayerBase()
        {
            // 在构造函数中 读取XML文件的数据
            //基础的数据 + 武器的数据 + 技能的数据
            
            

        }
        
        // 用不用属性来控制private的变量?

        #region MyRegion

        

        #endregion

        public void ResetPlayerAttrByWeapon()
        {
            
        }


        // 玩家的数值需要依据当前的装备再次算一遍
        public void ResetPlayerAttrByEquip()
        {
            // 在游戏的进入阶段，就会初始化PlayerOnEquipManager类
            
        }

        public void ResetPlayerAttrBySkill()
        {
            
            
        }
        
        //在进入游戏的时候在执行这个函数，构造函数的时候会报错
        public void ResetPlayerAttr()
        {
            ResetPlayerAttrByEquip();
            ResetPlayerAttrBySkill();
        }

        //todo:
        public static void GetPlayerDataByXML()
        {

        }

        private void OnDestroy()
        {
            
            Debug.LogError("static playerbase class delete");
            PlayerInstance = null;
        }


        // 减血和加血的重要的操作用单例类的两个方法来控制是不是又命题 ？？？？
        public void AddHealth(int count)
        {
            if((PlayerCurrentHealth + count)>=PlayerMaxHealth)
            {
                PlayerCurrentHealth = PlayerMaxHealth;
            }
            else
            {
                PlayerCurrentHealth = PlayerCurrentHealth+count;
            }
        }
        public void ReduceHealth(int count)
        {
             if((PlayerCurrentHealth + count)<=0)
            {
                PlayerCurrentHealth = 0;
                // 设置PlayerFsm的状态为dead
            }
            else
            {
                PlayerCurrentHealth = PlayerCurrentHealth+count;
            }
        }
        
    }
}
