using System;
using tools;
using UnityEngine;

namespace Player.PlayerBehaviour
{
    /// <summary>
    /// 此脚本挂在在PlayerOrigin上
    /// </summary>
    public class PlayerEquipWeapon : MonoBehaviour
    {
        private Transform SwordParentTrans;
        private void Start()
        {
            SwordParentTrans = GameObject.FindWithTag("SwordSocket").transform;
            //DeleteCurrentWeapon();
            //LoadWeapon("PT_Medieval_Longsword_04_b");
        }
        
        private void DeleteCurrentWeapon()
        {
            GameObject SwordTrans = GameObject.FindWithTag("Sword");
            DestroyImmediate(SwordTrans.gameObject);
        }
        private void LoadWeapon(string weapon_name)
        {
            string weapon_prefab_path = "Assets/Resources/Prefabs/Weapon/" + weapon_name;
            GameObject SwordPrefab = PrefabCacheUtil.GetPrefabByPath(weapon_prefab_path);
            var obj = Instantiate(SwordPrefab,SwordParentTrans);
            obj.transform.localPosition = new Vector3(0f,0f,-0.4f);
            obj.transform.localRotation = Quaternion.Euler(-100f, -30f, 30f);
        }
        
        


    }
}