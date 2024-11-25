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

    int number;

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        number = 20;
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
            stop = true;
            number = 200;
        }
        else
        {
            stop = false;
        }

        if (DistanceToPlayer > number && !stop)
        {
            enemy.speed = 6;
            follow();
        }
        else
        {
            enemy.speed = 0;
        }
        if(DistanceToPlayer <= 3 && !stop)
        {
            StartCoroutine(attack());
        }

    }

    void follow()
    {
        enemy.SetDestination(Player.transform.position);
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(2.5f);
        if (DistanceToPlayer <= 3 && !stop)
        {
            Player.GetComponent<Player_Health>().takeDamage(damage);
        }
        
    }
}
