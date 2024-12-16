using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
    private bool stop;
    int number;

    [SerializeField] private float awayDistance;
    // Start is called before the first frame update
    void Start()
    {
        
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Ray borderRay = new Ray(transform.position, player.transform.position - transform.position);

        RaycastHit borderHit;

        if (Physics.Raycast(borderRay, out borderHit, DistanceToPlayer, border))
        {
            if (!borderHit.collider.gameObject.CompareTag("Player"))
            {
                stop = true;
                number = 200;
            }
            else
            {
                stop = false;
            }
        }
        else
        {
            stop = false;
        }
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > awayDistance && !stop)
        {
            Move();
        }

        else if (distance < awayDistance && !stop)
        {
            MoveAway();
        }else if (Time.time > nextShotTime && !stop)
        {
            Instantiate(bullet, BulletPlace.transform.position, BulletPlace.transform.rotation);
            nextShotTime = Time.time + timeBetweenShots;
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
