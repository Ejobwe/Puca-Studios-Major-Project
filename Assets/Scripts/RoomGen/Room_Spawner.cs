using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.EditorTools;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public GameObject[] rooms;

    public Quaternion rota;

    // Start is called before the first frame update

    private void Start()
    {

        Instantiate(rooms[Random.Range(0, rooms.Length)], gameObject.transform);

    }
}
