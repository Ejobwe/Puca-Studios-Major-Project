using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Checker : MonoBehaviour
{
    

    public Transform leftWall;
    public Transform rightWall;
    public Transform backWall;
    public Transform frontWall;

    [SerializeField] private LayerMask wallCheck;

    RoomManager roomManager;

    // Start is called before the first frame update
    void Awake()
    {

        StartCoroutine(Delay());
        roomManager = transform.parent.GetComponent<RoomManager>();

    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Ray leftRay = new Ray(transform.position, Vector3.left);
        Ray rightRay = new Ray(transform.position, Vector3.right);
        Ray forwardRay = new Ray(transform.position, Vector3.forward);
        Ray backRay = new Ray(transform.position, Vector3.back);

        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit frontHit;
        RaycastHit backHit;

        if (Physics.Raycast(leftRay, out leftHit, 200f, wallCheck))
        {
            leftHit.collider.gameObject.GetComponent<Wall_Generator>().roomCount += 1;
            leftHit.collider.gameObject.GetComponent<Wall_Generator>().leftCam = roomManager.roomCam;

        }
        

        if (Physics.Raycast(rightRay, out rightHit, 200f, wallCheck))
        {
            rightHit.collider.gameObject.GetComponent<Wall_Generator>().roomCount += 1;
            rightHit.collider.gameObject.GetComponent<Wall_Generator>().rightCam = roomManager.roomCam;
        }
        

        if (Physics.Raycast(forwardRay, out frontHit, 200f, wallCheck))
        {
            frontHit.collider.gameObject.GetComponent<Wall_Generator>().roomCount += 1;
            frontHit.collider.gameObject.GetComponent<Wall_Generator>().frontCam = roomManager.roomCam;
        }
        

        if (Physics.Raycast(backRay, out backHit, 200f, wallCheck))
        {
            backHit.collider.gameObject.GetComponent<Wall_Generator>().roomCount += 1;
            backHit.collider.gameObject.GetComponent<Wall_Generator>().backCam = roomManager.roomCam;
        }
        

    }

    public void SpawnWalls()
    {

    }
}
