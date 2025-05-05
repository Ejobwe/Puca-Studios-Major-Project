using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.IsometricAiming;

public class LightningRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    //public Transform[] LightningTransforms;
    private IsometricAiming isometricAiming;
    private SpellCaster spellCaster;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
        isometricAiming = player.GetComponent<IsometricAiming>();
        spellCaster = player.GetComponent<SpellCaster>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        
        lineRenderer.SetPosition(1, isometricAiming.Pos);
    }
    void Update()
    {
        lineRenderer.SetPosition(0,player.transform.position);
    }
}
