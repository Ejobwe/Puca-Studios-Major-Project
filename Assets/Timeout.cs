using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeout : MonoBehaviour
{
    [SerializeField] private float timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SD(timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SD(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        Destroy(this.gameObject);
    }
}
