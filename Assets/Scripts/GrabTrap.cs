using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrap : MonoBehaviour
{
    private GameObject player;

    private PlayerMovement playerMovement;

    public void Start()
    {
        player = GameObject.Find("Player");

        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Trap());
        }
    }

    IEnumerator Trap()
    {
        if (playerMovement != null)
        {
            playerMovement.canMove = false;
            yield return new WaitForSecondsRealtime(2f);
            playerMovement.canMove = true;
        }
    }
}
