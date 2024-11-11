using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public GameObject[] rooms;
    private int rng;
    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(0, rooms.Length);
        Instantiate(rooms[rng], transform.position, Quaternion.identity);
        //rooms[rng].transform.GetChild(0).GetComponent<Wall_Generator>().SpawnWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
