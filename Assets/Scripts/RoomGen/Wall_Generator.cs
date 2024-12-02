using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class Wall_Generator : MonoBehaviour
{
    public float roomCount;

    public GameObject normalWall;
    public GameObject entranceWall;

    public CinemachineCamera frontCam;
    public CinemachineCamera backCam;
    public CinemachineCamera leftCam;
    public CinemachineCamera rightCam;


    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        SpawnWall();
    }
    public void SpawnWall()
    {
        if(roomCount > 1)
        {
            Instantiate(entranceWall, transform.parent.position, transform.parent.rotation,transform);
        }
        if(roomCount <= 1)
        {
            Instantiate(normalWall, transform.parent.position, transform.parent.rotation,transform);
        }
    }
    
}
