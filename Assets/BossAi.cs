using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public Animator moves;

    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking == false)
        {
            attacking = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        int i = Random.Range(1, 3);
        yield return new WaitForSeconds(3);

        if(i == 1)
            {
            StartCoroutine(Swing());
            }
        if(i == 2)
        {
            StartCoroutine(Slam());
        }
    }

    IEnumerator Swing()
    {
        moves.SetBool("Swing",true);

        yield return new WaitForSeconds(1);
        moves.SetBool("Swing", false);
        attacking = false;
    }
    IEnumerator Slam()
    {
        moves.SetBool("Slam", true);

        yield return new WaitForSeconds(1);
        moves.SetBool("Slam", false);
        attacking = false;
    }
}
