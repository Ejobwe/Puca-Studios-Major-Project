using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        GetComponent<CinemachineCamera>().Follow = target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
