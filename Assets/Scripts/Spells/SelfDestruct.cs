using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestruct(timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator selfDestruct(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
