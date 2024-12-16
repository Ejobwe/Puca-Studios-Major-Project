using System;
using System.Collections;
using System.Collections.Generic;
using BarthaSzabolcs.IsometricAiming;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    /* [SerializeField] private float Speed;
     [SerializeField] private GameObject Player;
     private IsometricAiming isometricAiming;
     private Vector3 Mpos;
     private float Step;


     private void Start()                                                                all of this script is to be dedicated to the fireballs effects.
     {
         isometricAiming = Player.GetComponent<IsometricAiming>();
         Mpos = isometricAiming.Dir;
         Step = Speed * Time.deltaTime;
         transform.Rotate(Mpos);
     }*/

    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Enemy")
        {
            other.collider.GetComponent<Enemy_Health>().takeDamage(damage);
            Destroy(this.gameObject);
        }
        
    }
}
