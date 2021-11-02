using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class AIBossBase : MonoBehaviour
{
   public GameObject Player;
   private NavMeshAgent bossnavmeshagent;
    private void Awake() 
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        bossnavmeshagent = this.GetComponent<NavMeshAgent>();
    }
    //单纯性的平A攻击
    public void AttackCommon()
    {
        bossnavmeshagent.destination = Player.gameObject.transform.position;
    }

    // 具体的技能释放的话依据不同的BOSS就提供几个方法 ，在基类中就不再写方法了
}
