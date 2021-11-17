using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class StatusUIControl : MonoBehaviour
{
    public GameObject StatusPre;
    private AIMonsterStatus aIMonsterStatus;

    public Transform PrefabStatusTrans;

    private Canvas StatusCanvas;
    private Transform InitedStatusUITrans;

    private void Awake()
    {
        foreach (var cans in FindObjectsOfType<Canvas>())
        {
            if (cans.tag == "StatusCanvas")
            {
                StatusCanvas = cans;
            }
        }
        aIMonsterStatus = this.GetComponent<AIMonsterStatus>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //test
        BleedStatus bleedStatus = new BleedStatus(5);
        aIMonsterStatus.AddAIMonsterStatus(bleedStatus);
        StartCoroutine(RefreshBySecondIEnum());
        //在创建status canvas上创建一个空物体
        GameObject StatusObject = new GameObject();
        StatusObject.name = "StatusObject";
        StatusObject.transform.SetParent(StatusCanvas.transform,true);
    }
    
    private void OnEnable()
    {
        aIMonsterStatus.status_event += GenerateStatusPrefab;
    }
    //update中仅检测状态的时间
    void Update()
    {
    }

    //状态持续时间-1
    void ReduceLastTimeBySecond()
    {
        List<SingleMonsterStatusBase> status_list= aIMonsterStatus.GetCurrentMonsterStatusList();
        if (status_list.Count == 0)
            return;
        for(int i =0;i<status_list.Count;i++)
        {
            status_list[i].last_time = status_list[i].last_time - Time.deltaTime;
            if (status_list[i].last_time  <= 0)
            {
                aIMonsterStatus.RemoveAIMnsterStatus(status_list[i]);
            }
        }
    }
    void GenerateStatusPrefab(string prefab_name,int type)
    {
        if (type == 1)
        {
            GameObject  obj = Instantiate(StatusPre, StatusCanvas.transform);
            obj.transform.position = PrefabStatusTrans.position;
        }
        else if (type==2)
        {
            DeleteStatusPrefab(prefab_name);
        }

    }

    void DeleteStatusPrefab(string prefab_name)
    {
        int child_count = StatusCanvas.transform.childCount;
        for(int i =0;i<child_count;i++)
        {
            GameObject status_prefab = StatusCanvas.transform.GetChild(i).gameObject;
            if(status_prefab.name == prefab_name)
            {
                Destroy(status_prefab);
            }
        }
    }

    private void LateUpdate()
    {
        
    }

    IEnumerator RefreshBySecondIEnum()
    {
        while(true)
        {
            ReduceLastTimeBySecond();
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnDestroy() {
        StopAllCoroutines();
    }
}

