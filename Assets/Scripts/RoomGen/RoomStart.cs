using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStart : MonoBehaviour
{
    public bool roomFinished;
    public bool bossRoom;

    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (roomFinished)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(roomFinished && bossRoom)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!roomFinished && !bossRoom)
            {
                StartCoroutine(spawnDelay());
            }
            if (!roomFinished && bossRoom)
            {
                StartCoroutine(spawnDelayBoss());
            }
        }
    }
    
    private IEnumerator spawnDelay()
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        spawner.GetComponent<EnemySpawner>().roomEntered = true;
    }
    private IEnumerator spawnDelayBoss()
    {
        yield return new WaitForSeconds(1);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
