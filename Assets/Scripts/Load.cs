using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    Movement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();
        StartCoroutine(load());
    }

    IEnumerator load()
    {

        yield return new WaitForSeconds(7);
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        gameObject.SetActive(false);
        player.canMove = true;

    }
}
