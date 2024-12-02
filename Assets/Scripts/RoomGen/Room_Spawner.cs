using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{
    public GameObject[] rooms;
    private int rng;
    private int roomSpawn;
    public bool spawn;
    public bool room;
    public bool rs;
    public int conection;
    public LayerMask roomLayer;

    private bool leftRay = true;
    private bool rightRay = true;
    private bool frontRay = true;
    private bool backRay = true;

    private bool chainSpawn;
    // Start is called before the first frame update

    private void Start()
    {
        if(spawn)
        {
            spawnRoom();
        }
       
    }
    private void Update()
    {
        if (rs && !chainSpawn)
        {
            spawnRoom();
        }
    }

    void roomCheck()
    {
        Ray roomCheckRight = new Ray(transform.position, Vector3.right);
        Ray roomCheckLeft = new Ray(transform.position, Vector3.left);
        Ray roomCheckFront = new Ray(transform.position, Vector3.forward);
        Ray roomCheckBack = new Ray(transform.position, Vector3.back);

        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit frontHit;
        RaycastHit backHit;

        if (Physics.Raycast(roomCheckLeft, out leftHit, 200f, roomLayer) && leftRay)
        {
            if (room)
            {
                leftHit.collider.GetComponent<Room_Spawner>().conection += 1;
            }
            leftHit.collider.GetComponent<Room_Spawner>().rs = true;
            leftRay = false;
        }
        if (Physics.Raycast(roomCheckRight, out rightHit, 200f, roomLayer) && rightRay)
        {
            if (room)
            {
                rightHit.collider.GetComponent<Room_Spawner>().conection += 1;
            }
            rightHit.collider.GetComponent<Room_Spawner>().rs = true;
            rightRay = false;
        }
        if (Physics.Raycast(roomCheckFront, out frontHit, 200f, roomLayer) && frontRay)
        {
            if (room)
            {
                frontHit.collider.GetComponent<Room_Spawner>().conection += 1;
            }
            frontHit.collider.GetComponent<Room_Spawner>().rs = true;
            frontRay = false;
        }
        if (Physics.Raycast(roomCheckBack, out backHit, 200f, roomLayer) && backRay)
        {
            if (room)
            {
                backHit.collider.GetComponent<Room_Spawner>().conection += 1;
            }
            backHit.collider.GetComponent<Room_Spawner>().rs = true;
            backRay = false;
        }
    }

    void spawnRoom()
    {
        
        
        if (conection == 0 && !spawn)
        {
            roomSpawn = 0;
        }
        if (conection == 1 && !spawn)
        {
            if(Random.value > 0.2)
            {
                roomSpawn = 1;
            }
            else
            {
                roomSpawn = 0;
            }
        }
        if (conection > 1 && !spawn)
        {
            if(Random.value > 0.3)
            {
                roomSpawn = 1;
            }
            else
            {
                roomSpawn = 0;
            }
        }

        if (spawn)
        {
            roomSpawn = 1;
            spawn = false;
        }

        
        switch (roomSpawn)
        {
            case 1:
                
                rng = Random.Range(0, rooms.Length);
                if(rng != 3)
                {
                    Instantiate(rooms[rng], transform.position, Quaternion.identity);
                    room = true;
                    rs = false;
                }


                if (rng == 3)
                {
                    Instantiate(rooms[rng], transform.position, Quaternion.identity);
                    room = true;
                    rs = false;
                }
                break;

            case 0:
                
                rs = false;
                
                break;
        }
        chainSpawn = true;
        
        roomCheck();
        
    }
}
