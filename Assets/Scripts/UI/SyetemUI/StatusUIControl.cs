using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUIControl : MonoBehaviour
{
    public GameObject StatusPre;
    private AIMonsterStatus aIMonsterStatus;

    public Transform PrefabStatusTrans;

    private Canvas StatusCanvas;
    private Transform InitedStatusUITrans;

    // Start is called before the first frame update
    void Start()
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

    private void OnEnable() {
    }
    //update中仅检测状态的时间
    void Update()
    {
        List<SingleMonsterStatus> status_list= aIMonsterStatus.GetCurrentMonsterStatusList();
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

    void GenerateStatusPrefab(string prefab_name)
    {
        Instantiate(StatusPre, StatusCanvas.transform);
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

}

