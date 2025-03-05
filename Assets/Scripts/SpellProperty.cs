using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpellProperty : MonoBehaviour
{
    [SerializeField] private SpellMixManager SMM;
    public bool Burning;
    public bool Wet;
    public GameObject combo;
    

void Start()
    {
        SMM = GameObject.Find("GameManager").GetComponent<SpellMixManager>();

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SpellProperty>())
        {
            SMM.Spells.Add(this.GameObject());
            SMM.Props.Add(this);
            combo = other.GameObject();
        }
    }

    private void OnDestroy()
    {
        SMM.Spells.Remove(this.GameObject());
        SMM.Props.Remove(this);
    }
}