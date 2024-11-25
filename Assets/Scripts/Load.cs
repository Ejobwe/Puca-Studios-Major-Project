using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{

    Image loadScreen;
    Movement player;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Movement>();
        loadScreen = GetComponent<Image>();
        StartCoroutine(load());
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(7f);
        loadScreen.color = new Color(0,0,0,0);
        player.canMove = true;
    }
}
