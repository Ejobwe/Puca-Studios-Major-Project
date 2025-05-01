using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class SpellProperty : MonoBehaviour
{
    public bool Burning;
    public bool Wet;
    public bool Metal;
    public bool Frozen;
    public bool Windy;
    public bool Electric;

    public List<SpellProperty> cantCheckProperties = new List<SpellProperty>();

    void FixedUpdate()
    {
        if(cantCheckProperties.Count > 0) cantCheckProperties = new List<SpellProperty>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<SpellProperty>(out SpellProperty SpellProperty))
        {
            print("Spellcollision");
            if(!cantCheckProperties.Contains(SpellProperty))
            {
                FindObjectOfType<SpellMixManager>().SpellFuse(this, SpellProperty);
                //SpellFuse(this, SpellProperty);
                SpellProperty.cantCheckProperties.Add(this);
            }
        }
    }
}