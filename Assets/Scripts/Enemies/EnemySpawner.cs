using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Waves;

    public bool roomEntered;
    // Start is called before the first frame update
    void Update()
    {
        if(roomEntered == true)
        {
            Spawn();
            roomEntered = false;
        }
    }

    void Spawn()
    {
        if (Waves[0] != null)
        {
            Waves[0].SetActive(true);
            if (Waves[0].transform.childCount == 0 && Waves[1] != null)
            {
                Waves[1].SetActive(true);
            }
            else
            {
                gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
            }
            if (Waves[1].transform.childCount == 0 && Waves[2] != null)
            {
                Waves[2].SetActive(true);
            }
            else
            {
                gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
            }
            if (Waves[2].transform.childCount == 0)
            {
                gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
            }
        }
    }
}
