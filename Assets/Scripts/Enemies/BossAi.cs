using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    private Animator anim;

    private Quaternion origin;

    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attacking = false;
        origin = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking == false)
        {
            attacking = true;
            anim.SetBool("Attack", true);
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, this.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z));
        //StartCoroutine(Wait());
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(1).length);
        anim.SetBool("Attack", false);
        StartCoroutine(Cooldown());


    }
    IEnumerator Cooldown()
    {
        
        yield return new WaitForSeconds(2);

        attacking = false;

    }
    

    //IEnumerator Swing()
    //{
    //    moves.SetBool("Swing",true);
    //    AudioManager.instance.PlayOneShot(FMODEvents.instance.bossEnemyAttack, transform.position);
    //    yield return new WaitForSeconds(1);
    //    moves.SetBool("Swing", false);
    //    attacking = false;
    //}
    //IEnumerator Slam()
    //{
    //    moves.SetBool("Slam", true);
    //    AudioManager.instance.PlayOneShot(FMODEvents.instance.bossEnemyAttack, transform.position);
    //    transform.LookAt(new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, this.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z));
    //    yield return new WaitForSeconds(1);
    //    moves.SetBool("Slam", false);
    //    attacking = false;
    //}
}
