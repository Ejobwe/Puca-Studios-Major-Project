using System;
using System.Collections;
using System.Collections.Generic;
using BarthaSzabolcs.IsometricAiming;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject Manager;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private GameObject SPObj;
    private Vector3 SpawnPoint;
    [SerializeField] private GameObject Player;
    private IsometricAiming isometricAiming;
    private Vector3 Mpos;
    private float Speed = 5f;

    private void Start()
    {
        isometricAiming = Player.GetComponent<IsometricAiming>();
        Mpos = isometricAiming.Dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnPoint = SPObj.transform.position;
            GameObject clone = Instantiate(Projectile, SpawnPoint, Quaternion.Euler(Mpos));
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
        }
        
    }
}
