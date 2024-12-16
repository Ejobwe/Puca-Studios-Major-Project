using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private int damage;
   
    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Player
        
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player_Health>().takeDamage(damage);
        }
        
    }
    private void OnEnable()
    {

        StartCoroutine(DestroyBulletAfterTime());

    }
}
