using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.IsometricAiming;

public class LightningRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform[] LightningTransforms;
    private IsometricAiming isometricAiming;
    private SpellCaster spellCaster;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        
    }

    
    void Update()
    {
        lineRenderer.SetPosition(1,spellCaster.SpawnPoint);
        lineRenderer.SetPosition(0, isometricAiming.Pos);
    }
}
