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
        Instantiate(StatusPre,StatusCanvas.transform);
    }

    private void OnEnable() {
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}

