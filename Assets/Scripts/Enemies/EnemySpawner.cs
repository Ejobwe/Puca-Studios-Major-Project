using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;

    public bool roomEntered;
    // Start is called before the first frame update
    void Update()
    {
        if(roomEntered == true)
        {
            Spawn();
            roomEntered = false;
        }
    }

    void Spawn()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], gameObject.transform);
    }
}
