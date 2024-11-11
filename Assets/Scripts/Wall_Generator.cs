using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Generator : MonoBehaviour
{

    public GameObject normalWall;

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

        if(Physics.Raycast(leftRay,out hit))
        {
            if(hit.collider.gameObject.tag == "Normal" )
            {
                Vector3 midpoint = (transform.position - hit.collider.transform.position);
                Instantiate(normalWall,leftWall.position,leftWall.rotation);
            }
        }
        if (Physics.Raycast(rightRay, out hit))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {
                Vector3 midpoint = (transform.position - hit.collider.transform.position);
                Instantiate(normalWall, rightWall.position, rightWall.rotation);
            }
        }
        if (Physics.Raycast(forwardRay, out hit))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {
                Vector3 midpoint = (transform.position - hit.collider.transform.position);
                Instantiate(normalWall, frontWall.position, frontWall.rotation);
            }
        }
        if (Physics.Raycast(backRay, out hit))
        {
            if (hit.collider.gameObject.tag == "Normal")
            {
                Vector3 midpoint = (transform.position - hit.collider.transform.position);
                Instantiate(normalWall, backWall.position, backWall.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
