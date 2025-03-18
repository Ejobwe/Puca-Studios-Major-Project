//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class SpellMixManager : MonoBehaviour
{
    public  List<GameObject>  Spells = new List<GameObject>();
    public List<SpellProperty> Props = new List<SpellProperty>();
    [SerializeField] private List<GameObject> Spellojects = new List<GameObject>();
    private int oldcount;

    public static SpellMixManager instance;

    private Vector3 FrozenSpeed;

    void Start()
    {
        if(instance != null && instance != this)
        {
            //DestroyAll(gameObject);
        }
        else
        {
            instance = this;
        }
        
        StartCoroutine(Flush());
    }

    
    /* void Update()
    {
        oldcount = Spells.Count;
        for (int i = 0; i < Spells.Count; i++)
        {
            for (int j = 0; j < Spells.Count; j++)
            {
                if (Props[i].combo == Spells[j])
                { 
                    SpellFuse(Props[i], Props[j]);
                    Debug.Log("tada");
                    break;
                }
            }
        }
    } */

    public void SpellFuse(SpellProperty SP1, SpellProperty SP2)
    {
        #region Wet/Burning
        if ((SP1.Burning || SP2.Burning) && (SP1.Wet || SP2.Wet))
        {
            if (SP1.Wet == true)
            {
                Instantiate(Spellojects[0],new Vector3(SP1.transform.position.x, SP1.transform.position.y, SP1.transform.position.z), Quaternion.identity);
            }
            if (SP2.Wet == true)
            {
                Instantiate(Spellojects[0],
                    new Vector3(SP2.transform.position.x, SP2.transform.position.y, SP2.transform.position.z), Quaternion.identity);
            }
            DestroyAll(SP1.GameObject(),SP2.GameObject());
        }
        #endregion

        #region Wet/Frozen
        if((SP1.Frozen || SP2.Frozen) && (SP1.Wet || SP2.Wet))
        {
            if(SP1.Wet == true)
            {
                SP1.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(FrozenSpeed);;
                SP1.Frozen = true;
                SP1.Wet = false;
            }
            if(SP2.Wet == true)
            {
                SP1.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(FrozenSpeed);;
                SP2.Frozen = true;
                SP2.Wet = false; 
            }
        }
        #endregion

        #region Frozen/Steel
        if((SP1.Frozen || SP2.Frozen) && (SP1.Metal || SP2.Metal))
        {
            if(SP1.Frozen == true)
            {
                for(int i = 0; i < 10; i++)
                {
                    Vector3 randir = new Vector3((Random.Range(-1f,1f) * 10),0f,(Random.Range(-1f,1f) * 10));
                  GameObject shard = Instantiate(Spellojects[1],new Vector3(SP1.transform.position.x, SP1.transform.position.y, SP1.transform.position.z),Quaternion.Euler(SP1.gameObject.transform.localRotation.eulerAngles));
                    shard.GetComponent<Rigidbody>().velocity = randir;
                }
                Destroy(SP1.gameObject);
            }
            if(SP2.Frozen == true)
            {
                for(int i = 0; i < 10; i++)
                {
                    Vector3 randir = new Vector3((Random.Range(-1f,1f) * 10),0f,(Random.Range(-1f,1f) * 10));
                    GameObject shard = Instantiate(Spellojects[1],new Vector3(SP2.transform.position.x, SP2.transform.position.y, SP2.transform.position.z), Quaternion.Euler(SP2.gameObject.transform.localRotation.eulerAngles));
                    shard.GetComponent<Rigidbody>().velocity = randir;
                }
                Destroy(SP2.gameObject);
            }
        }
        #endregion
    }
        
    #region Flush

    

    
    private IEnumerator Flush()
    {
        for (int i = 0; i < Spells.Count; i++)
        {
            if (null == Spells[i])
            {
                Spells.Remove(Spells[i]);
            }
        }
        for (int i = 0; i < Props.Count; i++)
        {
            if (Props[i] == null)
            {
                Props.Remove(Props[i]);
            }
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Flush());
    }
    #endregion

    private void DestroyAll(GameObject S1, GameObject S2)
    {
        Destroy(S1);
        Destroy(S2);
    }
}