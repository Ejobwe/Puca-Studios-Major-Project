using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Wall_Generator : MonoBehaviour
{
    public float roomCount;
    public bool isLongRoom;


    public GameObject normalWall;
    public GameObject entranceWall;

    public CinemachineCamera frontCam;
    public CinemachineCamera backCam;
    public CinemachineCamera leftCam;
    public CinemachineCamera rightCam;

    [SerializeField] private LayerMask wallCheck;


    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(17);
        if (isLongRoom)
        {
            Ray backRay = new Ray(transform.position, Vector3.back);
            RaycastHit backHit;

            if (Physics.Raycast(backRay, out backHit, 200f, wallCheck))
            {
                backHit.collider.gameObject.GetComponent<Wall_Generator>().roomCount += 1;
                backHit.collider.gameObject.GetComponent<Wall_Generator>().backCam = backCam;
                backHit.collider.GetComponent<Wall_Generator>().SpawnWall();
            }
        }
        SpawnWall();
    }
    public void SpawnWall()
    {
        if(roomCount > 1 && !isLongRoom)
        {
            Instantiate(entranceWall, transform.parent.position, transform.parent.rotation,transform);
        }
        if(roomCount <= 1 && !isLongRoom)
        {
            Instantiate(normalWall, transform.parent.position, transform.parent.rotation,transform);
        }
        
    }
    
}
