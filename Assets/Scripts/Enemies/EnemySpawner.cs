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
            
        }

    }

    void Spawn()
    {
        if (Waves[0] != null)
        {
            Waves[0].SetActive(true);
            if (Waves[0].transform.childCount == 0 && 1 != Waves.Length)
            {
                Waves[1].SetActive(true);
            }
            else if (Waves[0].transform.childCount == 0)
            {
                gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
            }
            if (2 == Waves.Length)
            {
                if (Waves[1].transform.childCount == 0 && 2 != Waves.Length)
                {
                    Waves[2].SetActive(true);
                }
                else if (Waves[1].transform.childCount == 0)
                {
                    gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
                }
            }
            if (3 == Waves.Length)
            {
                if (Waves[2].transform.childCount == 0)
                {
                    gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;
                }
            }
            //for (int i = 0; i < Waves.Length;)
            //{
            //    Waves[i].SetActive(true);
            //    if (Waves[i].transform.childCount == 0 && i + 1 == Waves.Length)
            //    {
            //        roomEntered = false;
            //        gameObject.transform.parent.transform.GetComponent<RoomStart>().roomFinished = true;

            //    }

            //}
        }
    }
}
