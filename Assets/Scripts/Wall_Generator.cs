using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Generator : MonoBehaviour
{

    public GameObject normalWall;
    public GameObject entranceWall;

    public Transform leftWall;
    public Transform rightWall;
    public Transform backWall;
    public Transform frontWall;

    // Start is called before the first frame update
    void Start()
    {
        Ray leftRay = new Ray (transform.position,Vector3.left);
        Ray rightRay = new Ray(transform.position, Vector3.right);
        Ray forwardRay = new Ray(transform.position, Vector3.forward);
        Ray backRay = new Ray(transform.position, Vector3.back);

        RaycastHit hit;

        if(Physics.Raycast(leftRay,out hit,100f))
        {
            if(hit.collider.gameObject.tag == "Normal" )
            {    
                Instantiate(entranceWall,leftWall.position,leftWall.rotation);
            }
            
        }
        else
        {
            Debug.Log("hELLo");
            Instantiate(normalWall, leftWall.position, leftWall.rotation);
        }
        if (Physics.Raycast(rightRay, out hit,100f))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {               
                Instantiate(entranceWall, rightWall.position, rightWall.rotation);
            }
        }
        else
        {
            Instantiate(normalWall, rightWall.position, rightWall.rotation);
        }
        if (Physics.Raycast(forwardRay, out hit, 100f))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {              
                Instantiate(entranceWall, frontWall.position, frontWall.rotation);
            }
        }
        else
        {
            Instantiate(normalWall, frontWall.position, frontWall.rotation);
        }
        if (Physics.Raycast(backRay, out hit,100f))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {             
                Instantiate(entranceWall, backWall.position, backWall.rotation);
            }
        }
        else
        {
            Instantiate(normalWall, backWall.position, backWall.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
