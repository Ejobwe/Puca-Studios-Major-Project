using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public GameObject[] rooms;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
