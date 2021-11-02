using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ServerGuilt;
using UnityEngine.AI;
using UnityEditor;
using Player;
[System.Serializable]
[RequireComponent(typeof(NavMeshAgent))]
public class NpcSample : NpcBaseAI
{

    public EnumClass.NPC_BEhaviors this_npc_status;
    // Start is called before the first frame update
    private Animator npc_animator;
    [Tooltip("��һ��ΪNPC�ĵ�ǰλ��")]
    public List<Transform> npc_move_trans_list= new List<Transform>();
    public float move_speed = 1.5f;
    private NavMeshAgent nav;
    //public Transform parent_transform;
    [SerializeField]
    private int cur_position_index = 0;
    [SerializeField]
    private int next_position_index = 0;
    public Transform this_npc_Pos ;

    private int walk_hash;
    private int run_hash;
    private int doing_work_hash;
    private int talking_hash;
     void Start()
    {
        base.Start();
        npc_animator = Npc_base_animator[0];
        nav = GetComponent<NavMeshAgent>();
        TransAnimatorString2Hash();
        if(this_npc_status == EnumClass.NPC_BEhaviors.RUN)
            move_speed = 4.5f;
        nav.speed = move_speed;
    }


    void TransAnimatorString2Hash()
    {
        walk_hash = Animator.StringToHash("IsWalking");
        run_hash = Animator.StringToHash("IsRunning");
        doing_work_hash = Animator.StringToHash("IsDoingWork");
        talking_hash = Animator.StringToHash("IsTalking");
    }



    // Update is called once per frame
    // �����AI��Ѱ·
    void Update()
    {
        
        switch (this_npc_status)
        {
            case EnumClass.NPC_BEhaviors.WALK:
                // play walk animation 
                Vector3 lcoal_pos = npc_move_trans_list[cur_position_index].localPosition;
                // ������ж���Ҫ�õ�ǰ��������position
                float distence = Vector3.Distance(this_npc_Pos.localPosition,lcoal_pos);;
                if (distence <= 0.1f)
                {
                    if (next_position_index == npc_move_trans_list.Count - 1)
                    {
                        next_position_index = 0;
                    }
                    else
                        next_position_index += 1;

                    cur_position_index = next_position_index;
                }
                nav.destination = npc_move_trans_list[cur_position_index].position;
                // ������NPCû����������Ϊ��Ĭ��һֱ����animator
                npc_animator.SetBool(walk_hash,true);
                npc_animator.SetBool(run_hash, false);
                break;
            case EnumClass.NPC_BEhaviors.RUN:
                Vector3 lcoal_pos_run = npc_move_trans_list[cur_position_index].localPosition;
                // ������ж���Ҫ�õ�ǰ��������position
                float distence_run = Vector3.Distance(this_npc_Pos.localPosition, lcoal_pos_run); ;
                if (distence_run <= 0.1f)
                {
                    if (next_position_index == npc_move_trans_list.Count - 1)
                    {
                        next_position_index = 0;
                    }
                    else
                        next_position_index += 1;

                    cur_position_index = next_position_index;
                }
                nav.destination = npc_move_trans_list[cur_position_index].position;
                // ������NPCû����������Ϊ��Ĭ��һֱ����animator
                npc_animator.SetBool(run_hash, true);
                npc_animator.SetBool(walk_hash, false);
                break;
            case EnumClass.NPC_BEhaviors.Talking:
                npc_animator.SetBool(talking_hash, true);
                break;
            case EnumClass.NPC_BEhaviors.DONGWORK:
                break;




        }
    }

}
