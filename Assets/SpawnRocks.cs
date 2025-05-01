using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rockspawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Rockspawning()
    {
        Instantiate(Rock, this.transform.position, Quaternion.identity );
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Rockspawning());
        yield return null;
    }
}
