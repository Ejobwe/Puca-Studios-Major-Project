using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public float DistanceToPlayer;
    NavMeshAgent enemy;
    public LayerMask border;

    public int damage;
    public bool stop;

    int number = 20;

    private GameObject Player;

    [SerializeField] private float awayDistance;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player");  
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        Ray borderRay = new Ray(transform.position, Player.transform.position - transform.position);

        RaycastHit borderHit;
        
        if(Physics.Raycast(borderRay, out borderHit, DistanceToPlayer, border))
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

        
        if (DistanceToPlayer > 3 && !stop && number > 30)
        {
            Move();
        }
        else
        if(DistanceToPlayer <= 3)
        {
            StartCoroutine(attack());
        }
    }

    

    void Move()
    {
        enemy.SetDestination(Player.transform.position);
        enemy.stoppingDistance = awayDistance;
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(2.5f);
        if (DistanceToPlayer <= 3)
        {
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
