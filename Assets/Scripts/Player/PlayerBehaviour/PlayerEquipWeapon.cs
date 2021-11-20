﻿using System;
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
            DeleteCurrentWeapon();
        }
        
        private void DeleteCurrentWeapon()
        {
            GameObject SwordTrans = GameObject.FindWithTag("Sword");
            DestroyImmediate(SwordTrans.gameObject);
        }
        private void LoadWeapon(string weapon_name)
        {
            GameObject SwordPrefab = PrefabCacheUtil.GetPrefabByPath(weapon_name);
            Vector3 init_position = new Vector3(0, 0, 0);
            Instantiate(SwordPrefab, init_position, Quaternion.Euler(0f,0f,0f), SwordParentTrans);
        }
        



    }
}