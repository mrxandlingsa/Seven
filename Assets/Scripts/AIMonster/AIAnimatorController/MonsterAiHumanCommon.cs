/*
 * @Author: your name
 * @Date: 2021-10-30 19:42:32
 * @LastEditTime: 2021-10-31 15:33:36
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * 此处的monster是否也设计成为FSM???
 * @FilePath: \Seven\Assets\Scripts\AIMonster\AIAnimatorController\MonsterAiHumanCommon.cs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ServerGuilt;
using System;



namespace  AIMonster
{
    [RequireComponent(typeof(NavMeshAgent))]
    [System.Serializable]
    public class MonsterAiHumanCommon :BaseMonstorController
    {
        [Header("��ʼ״̬")]
        public EnumClass.HumanMonsterType init_status;

        [SerializeField]
        private EnumClass.HumanMonsterType cur_status;

        private float last_attack_time;
        // ��ҵ�object
        private GameObject player_attack_target;

        public int AttackForce;

        private Animator animator;
        private NavMeshAgent enemy_nav;
        [Header("�����룬��ҽ��빥��")]
        public int sight_radius = 3;

        [Header("���͵���AI���ƶ��ٶ�")]
        public float enemy_patrol_speed = 1.3f;
        public float enemt_chase_speed = 2.85f;
        [SerializeField]
        private Vector3 init_transform;

        private Vector3 way_point;
        public float sphere_range = 4;
        [SerializeField]
        private Vector3 random_pos;
        private void Awake()
        {
            this.cur_status = this.init_status;
            animator = this.GetComponent<Animator>();
            enemy_nav = this.GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            init_transform = this.transform.position;
            random_pos = GetNewWayPoint();


        }

        private void Update()
        {
            SwitchStatus();
            SwitchAnimation();
        }

        private void SwitchAnimation()
        {
            animator.SetBool("IsRun", this.cur_status == EnumClass.HumanMonsterType.Chase);
            animator.SetBool("IsWalk", this.cur_status == EnumClass.HumanMonsterType.Patrol);
        }

        private void SwitchStatus()
        {
            if (IsFindPlayer())
            {
                //Debug.LogError("has find player");
                this.cur_status = EnumClass.HumanMonsterType.Chase;
            }

            // ������ԭʼ��λ�� �ͽ��� init status 
            if (Vector3.Distance(this.transform.position, init_transform) <= 0.1f && (this.cur_status != EnumClass.HumanMonsterType.Chase))
            {
                this.cur_status = this.init_status;
            }


            switch (cur_status)
            {
                case EnumClass.HumanMonsterType.Chase:
                    //TODO: ׷�����
                    //TODO: ���ص�Ѳ��״̬
                    //TODO: �ڹ�����Χ�ڹ���
                    //TODO: play animation 
                    enemy_nav.speed = enemt_chase_speed;
                    if (IsFindPlayer())
                    {
                        enemy_nav.destination = player_attack_target.transform.position;
                    }
                    else
                    {
                        // ����Ѳ�ߵ�״̬
                        cur_status = EnumClass.HumanMonsterType.Patrol;
                    }    



                    break;
                case EnumClass.HumanMonsterType.Patrol:
                    enemy_nav.speed = enemy_patrol_speed;
                    // �������AI�� ����Զ���ʼ�ĵ�Ļ����ص�ԭ�㣬�������Ѳ��
                    float distance_away = Vector3.Distance(this.transform.position, this.init_transform);
                    if (distance_away >= sight_radius)
                    {
                        enemy_nav.destination = this.init_transform;
                    }
                    else
                    {
                        if (Vector3.Distance(this.random_pos, this.transform.position) <= enemy_nav.stoppingDistance)
                        {
                            this.random_pos = GetNewWayPoint();
                        }
                        else
                        {
                            enemy_nav.destination = random_pos;
                        }
                    }
                    break;
                case EnumClass.HumanMonsterType.Doingwork:
                    break;
                case EnumClass.HumanMonsterType.Talking:
                    break;
                case EnumClass.HumanMonsterType.Dead:
                    break;
            }
        }

        //TODE:
        void MoveToPlayer(GameObject player_target)
        { 
            
            
            
        }


        private bool IsFindPlayer()
        {
            var colliders = Physics.OverlapSphere(transform.position, sight_radius);

            foreach (var target in colliders)
            {
                if (target.CompareTag("Player"))
                {
                    player_attack_target = target.gameObject;
                    return true;
                }
            }
            player_attack_target = null;
            return false;
        
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, sight_radius);
        }

        Vector3 GetNewWayPoint()
        {
            float rendomX = UnityEngine.Random.Range(-sphere_range,sphere_range);
            float rendomZ = UnityEngine.Random.Range(-sphere_range, sphere_range);
            Vector3 random_point = new Vector3(this.init_transform.x + rendomX,this.init_transform.y, this.init_transform.z + rendomZ);
            return random_point;
        }


    }
    
}
