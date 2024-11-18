using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Vector3 DistanceToPlayer;

    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;  
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToPlayer = transform.position - Player.position;


    }
}
