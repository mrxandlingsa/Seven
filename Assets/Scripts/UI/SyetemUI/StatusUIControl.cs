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
        aIMonsterStatus = this.GetComponent<AIMonsterStatus>();
        BleedStatus test_status = new BleedStatus(10);
        //aIMonsterStatus.AddAIMonsterStatus(test_status);
    }

    private void OnEnable() 
    {
        foreach (var cans in FindObjectsOfType<Canvas>())
        {
         if (cans.tag == "StatusCanvas")
         {
            StatusCanvas = cans;
         }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < aIMonsterStatus.GetCurrentMonsterStatusList().Count; i++)
        {
            Instantiate(StatusPre, StatusCanvas.transform);
        }
    }

}

