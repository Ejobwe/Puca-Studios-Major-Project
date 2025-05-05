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
        var cloud = new Vector3(Random.Range(-2.0f, 2.0f), 5, Random.Range(-2.0f, 2.0f));
        Instantiate(Rock, this.transform.position+cloud, Quaternion.identity );
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Rockspawning());
        yield return null;
    }
}
