using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;
using FMOD.Studio;

public class BasicRangedAI : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    public GameObject bullet;
    private float nextShotTime;
    public float timeBetweenShots;
    public GameObject BulletPlace;

    public LayerMask border;
    public float DistanceToPlayer;
    public bool stop;
    public int number = 20;

    private Rigidbody Rb;

    public Transform enemyBottom;

    public EventInstance enemyFootsteps;

    [SerializeField] private float awayDistance;
    // Start is called before the first frame update
    void onAwake()
    {
        enemyFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.eightLeggedEnemyFootsteps);

        UpdateSound();

        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Ray borderRay = new Ray(transform.position, player.transform.position - transform.position);
        //
        //RaycastHit borderHit;
        //
        //if (Physics.Raycast(borderRay, out borderHit, DistanceToPlayer, border))
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
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > awayDistance && !stop && DistanceToPlayer < 30)
        {
            Move();
        }

        else if (distance < awayDistance && !stop && number > 30)
        {
            MoveAway();
            if (Time.time > nextShotTime && !stop && number > 30)
            { 
                Instantiate(bullet, BulletPlace.transform.position, BulletPlace.transform.rotation);
            nextShotTime = Time.time + timeBetweenShots;
            }
     }

        //Debug.Log(gameObject.name + gameObject.GetComponent<Rigidbody>().velocity);

    }
    void Move()
    {
        enemy.SetDestination(player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }
    void MoveAway()
    {
        Vector3 dirToPlayer = transform.position - player.transform.position;
        Vector3 newPos = transform.position + dirToPlayer;
        enemy.SetDestination(newPos);
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
