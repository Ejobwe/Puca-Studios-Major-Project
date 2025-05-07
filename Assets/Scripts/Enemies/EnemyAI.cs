using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;

public class EnemyAI : MonoBehaviour
{

    private float DistanceToPlayer;
    private NavMeshAgent enemy;
    public LayerMask border;

    public int damage;
    public bool stop;

    private GameObject Player;

    private Rigidbody Rb;
    public Animator anim;

    public Transform enemyBottom;

    public EventInstance enemyFootsteps;

    [SerializeField] private float awayDistance;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");
        Rb = GetComponent<Rigidbody>();
        enemyFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.sixLeggedEnemyFootsteps);

        UpdateSound();
    }

    // Update is called once per frame
    void Update()
    {
        
        DistanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        //Ray borderRay = new Ray(transform.position, Player.transform.position - transform.position);
        //
        //RaycastHit borderHit;
        //
        //if(Physics.Raycast(borderRay, out borderHit, DistanceToPlayer, border))
        //{
        //    if (!borderHit.collider.gameObject.CompareTag("Player"))
        //    {
        //        stop = true;
        //        number = 200;
        //    }
        //    else
        //    {
        //        stop = false;
        //    }
        //}
        //else
        //{
        //    stop = false;
        //}

        
        if (DistanceToPlayer > 3)
        {
            Move();
        }
        else
        if(DistanceToPlayer <= 3)
        {
            StartCoroutine(attack());
        }
    }

    private void FixedUpdate()
    {
        UpdateSound();
    }

    private void UpdateSound()
    {
        enemyFootsteps.set3DAttributes(RuntimeUtils.To3DAttributes(enemyBottom.position));

        if (Rb.velocity.x != 0f)
        {
            PLAYBACK_STATE playbackState;
            enemyFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                enemyFootsteps.start();
        }
        else if (Rb.velocity.z != 0f)
        {
            PLAYBACK_STATE playbackState;
            enemyFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                enemyFootsteps.start();
        }
        else if (Rb.velocity.z != 0f && Rb.velocity.x != 0f)
        {
            PLAYBACK_STATE playbackState;
            enemyFootsteps.getPlaybackState(out playbackState);

            if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                enemyFootsteps.start();
        }
        else
        {
            enemyFootsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    void Move()
    {
        enemy.SetDestination(Player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }

    IEnumerator attack()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        anim.SetBool("Attack", false);
        if (DistanceToPlayer <= 3)
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.meleeEnemyAttack, transform.position);
            Player.GetComponent<Player_Health>().takeDamage(damage);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "IceSpell")
        {
            GetComponent<NavMeshAgent>().speed = 2.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "IceSpell")
        {
            GetComponent<NavMeshAgent>().speed = 5;
        }
    }
}
