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

    public bool longRoom;
    public bool longRoomSpawnDown;
    public bool chainSpawn;
    public bool detected;

    public int rayDirection = 0;
    public int check;

    private Vector3 longRoomDown;
    // Start is called before the first frame update

    private void Start()
    {
        if(spawn)
        {
            StartCoroutine(spawnRoom());
        }
        longRoomDown = transform.position;
    }
    private void Update()
    {
        if (rs && !chainSpawn && !longRoom)
        {
            StartCoroutine(spawnRoom());
            chainSpawn = true;
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
        RaycastHit backHit;

        if (Physics.Raycast(roomCheckBack, out backHit, 200f, roomLayer) && longRoomSpawnDown)
        {
            backHit.collider.GetComponent<Room_Spawner>().longRoom = true;
        }
        if(check < 3 || !detected)
        {

            switch (rayDirection)
            {
                case 0:
                    if (Physics.Raycast(roomCheckLeft, out leftHit, 200f, roomLayer))
                    {
                        //skip to next side
                        if (leftHit.collider.GetComponent<Room_Spawner>().chainSpawn == true || leftHit.collider.GetComponent<Room_Spawner>().detected)
                        {
                            rayDirection = 1;
                            check += 1;
                            roomCheck();
                        }
                        else
                        {
                            if (room || longRoom)
                            {
                                leftHit.collider.GetComponent<Room_Spawner>().conection += 1;
                            }
                            leftHit.collider.GetComponent<Room_Spawner>().rs = true;
                            leftRay = false;
                            detected = true;
                            if (leftHit.collider.GetComponent<Room_Spawner>().longRoom && !leftHit.collider.GetComponent<Room_Spawner>().detected)
                            {
                                leftHit.collider.GetComponent<Room_Spawner>().roomCheck();
                            }
                            
                        }
                    }
                    if (leftHit.collider == null && check < 3)
                    {
                        check += 1;
                        rayDirection = 1;
                        roomCheck();
                        Debug.Log("ChangeLeft");
                    }

                    break;
                case 2:
                    if (Physics.Raycast(roomCheckBack, out backHit, 200f, roomLayer))
                    {
                        if (backHit.collider.GetComponent<Room_Spawner>().chainSpawn == true || backHit.collider.GetComponent<Room_Spawner>().detected)
                        {
                            rayDirection = 0;
                            check += 1;
                            roomCheck();
                        }
                        else
                        {
                            if (room || longRoom)
                            {
                                backHit.collider.GetComponent<Room_Spawner>().conection += 1;
                            }
                            if (longRoomSpawnDown)
                            {
                                backHit.collider.GetComponent<Room_Spawner>().roomCheck();
                            }

                            backHit.collider.GetComponent<Room_Spawner>().rs = true;
                            detected = true;
                        }
                    }
                    if (backHit.collider == null && check < 3)
                    {
                        rayDirection = 0;
                        check += 1;
                        roomCheck();
                        Debug.Log("ChangeBack");
                    }

                    break;
                case 1:
                    if (Physics.Raycast(roomCheckRight, out rightHit, 200f, roomLayer))
                    {
                        if (rightHit.collider.GetComponent<Room_Spawner>().chainSpawn == true || rightHit.collider.GetComponent<Room_Spawner>().detected)
                        {
                            rayDirection = 2;
                            check += 1;
                            roomCheck();
                        }
                        else
                        {
                            if (room || longRoom)
                            {
                                rightHit.collider.GetComponent<Room_Spawner>().conection += 1;
                            }
                            rightHit.collider.GetComponent<Room_Spawner>().rs = true;
                            rightRay = false;
                            detected = true;
                            if (rightHit.collider.GetComponent<Room_Spawner>().longRoom && !rightHit.collider.GetComponent<Room_Spawner>().detected)
                            {
                                rightHit.collider.GetComponent<Room_Spawner>().roomCheck();
                            }
                            
                        }
                    }

                    if (rightHit.collider == null && check < 3)
                    {
                        rayDirection = 2;
                        check += 1;
                        roomCheck();
                        Debug.Log("ChangeRight");
                    }

                    break;

            }
        }

        
        
        //if (Physics.Raycast(roomCheckFront, out frontHit, 200f, roomLayer) && frontRay)
        //{
        //    if (room)
        //    {
        //        frontHit.collider.GetComponent<Room_Spawner>().conection += 1;
        //    }
        //    frontHit.collider.GetComponent<Room_Spawner>().rs = true;
        //    frontRay = false;
        //}

    }

    IEnumerator spawnRoom()
    {
        
        yield return new WaitForSeconds(1);
        if (conection == 0 && !spawn)
        {
            roomSpawn = 0;
        }
        if (conection == 1 && !spawn)
        {
            if(Random.value > 0)
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
            if(Random.value > 0)
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
                if(rooms[rng].name != "LongRoom")
                {
                    Instantiate(rooms[rng], transform.position, Quaternion.identity);
                    room = true;
                    rs = false;
                    roomCheck();
                }


                if (rooms[rng].name == "LongRoom")
                {
                    Instantiate(rooms[rng], transform.position, Quaternion.identity);
                    longRoom = true;
                    longRoomSpawnDown = true;
                    rs = false;
                    roomCheck();
                }
                break;

            case 0:
                
                rs = false;
                roomCheck();
                break;
        }
        
       
        
    }
}
