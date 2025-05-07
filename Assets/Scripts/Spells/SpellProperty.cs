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
    public bool Planty;
    public bool Earthy;
    public float Damage;

    public List<SpellProperty> cantCheckProperties = new List<SpellProperty>();
    public float Lifetime;
    public bool Extended;
    public float Extension;
    public bool Extending;
    

    void Start()
    {
        StartCoroutine(selfDestruct(Lifetime));
    }



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
    
    private IEnumerator selfDestruct(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (!Extended)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Extend(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        
        if (Extended == true && Extending == false)
        {
            StartCoroutine(Extend(Extension));
            Extending = true;
        }
    }
}