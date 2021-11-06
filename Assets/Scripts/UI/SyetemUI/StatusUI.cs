using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//角色状态
///人物有有X种状态，就init
public class Status : MonoBehaviour {
    public GameObject StatusPre;
    private AIMonsterStatus aIMonsterStatus;

    public Transform PrefabStatusTrans;

    private Canvas StatusCanvas;

    private void Start() 
    {
        this.StatusCanvas = GameObject.Find("StatusCanvas").GetComponent<Canvas>();
        aIMonsterStatus = this.GetComponent<AIMonsterStatus>();
    }
    private  void OnEnable() 
    {
        //TODO:
    }

    private void Update() 
    {
        List<SingleMonsterStatus> current_frame_status = aIMonsterStatus.GetCurrentMonsterStatusList();
        //TODO:
        // 原本设定最大的状态数为5，以后在改吧
        for(int i =0;i<current_frame_status.Count;i++)
        {
            int pair = i/2+1;
            if(i%2==0)
            {
                Vector3 InitPos =new  Vector3(PrefabStatusTrans.position.x+50*pair,PrefabStatusTrans.position.y,PrefabStatusTrans.position.z);
                Instantiate(StatusPre,InitPos,PrefabStatusTrans.rotation);

            }
            else 
            {
                Vector3 InitPos =new  Vector3(PrefabStatusTrans.position.x-50*pair,PrefabStatusTrans.position.y,PrefabStatusTrans.position.z);
                Instantiate(StatusPre,InitPos,PrefabStatusTrans.rotation);
            }

        }
    }

    void RefreshStatusTime()
    {

    }
}
