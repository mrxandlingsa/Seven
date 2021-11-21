using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
/// <summary>
/// 此脚本为让人物或怪物在两点（多点之间巡逻）
/// </summary>
[System.Serializable]
[RequireComponent(typeof(NavMeshAgent))]
public class MoveBetween2Points : MonoBehaviour
{
    public int transform_count = 2;
    public List<Transform> patrol_list = new List<Transform>();
    private NavMeshAgent naveMeshAgent;
    private int currentRouteIndex = 0;

    public int agentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        naveMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, patrol_list[currentRouteIndex].position) <= 0.5f)
        {
            currentRouteIndex++;
            if (currentRouteIndex == patrol_list.Count)
            {
                currentRouteIndex = 0; 
            }
        }
        else
        {
            naveMeshAgent.destination = patrol_list[currentRouteIndex].position;
        }
    }

}
