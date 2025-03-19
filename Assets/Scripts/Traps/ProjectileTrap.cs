using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileTrap : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BulletPlace;
    private bool isShooting;

    public float timeBetweenShots;

    private void FixedUpdate()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bullet, BulletPlace.transform.position, BulletPlace.transform.rotation);
        yield return new WaitForSecondsRealtime(timeBetweenShots);
        isShooting = false;       
    }
}
