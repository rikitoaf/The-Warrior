using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{

    private CharacterAnimations enemy_Anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;

    public float move_speed = 3.5f;

    public float attack_Distance = 1f;
    public float chase_Player_After_Attack_Distance = 1f;

    private float wait_Before_Attact_Time = 3f;
    private float attack_Timer;

    private EnemyState enemy_State;

    public GameObject attackPoint;

    private CharecterSoundFX soundFx;


    // Start is called before the first frame update
    void Awake()
    {
        enemy_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;

        soundFx = GetComponentInChildren<CharecterSoundFX>();
    }

    void Start()
    {
        enemy_State = EnemyState.CHASE;
        attack_Timer = wait_Before_Attact_Time;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_State == EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if (enemy_State == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_speed;

        if (navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_Anim.Walk(false);
        }
        else
        {
            enemy_Anim.Walk(true);
        }
        
        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemy_Anim.Walk(false);
        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_Before_Attact_Time)
        {
            if (Random.Range(0, 2) > 0)
            {
                enemy_Anim.Attack_1();
                soundFx.Attack_1();
            }
            else
            {
                enemy_Anim.Attack_2();
                soundFx.Attack_2();
            }
            attack_Timer = 0f;
        }

        if (Vector3.Distance(transform.position,playerTarget.position)>attack_Distance + chase_Player_After_Attack_Distance)
        {
            navAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deactivate_AttackPoint()
    {
        
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
