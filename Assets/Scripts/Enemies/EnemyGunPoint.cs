using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunPoint : MonoBehaviour
{
    public Transform player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.LookAt(player);
    }
}
