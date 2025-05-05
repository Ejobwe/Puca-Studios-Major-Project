using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private GameObject child;



    private void Update()
    {
        if (child == null)
        {
            Destroy(this.gameObject);
        }
    }
}
