using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        StartCoroutine(load());
    }

    IEnumerator load()
    {

        yield return new WaitForSeconds(20);
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        gameObject.SetActive(false);
        player.canMove = true;

    }
}
