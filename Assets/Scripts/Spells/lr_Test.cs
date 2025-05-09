using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_Test : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Linerender_lr lr;
    private void Start()
    {
        lr.SetUpLine(points);
    }
    
}
