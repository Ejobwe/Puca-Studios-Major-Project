//using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class SpellMixManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> Spellojects = new List<GameObject>();
    [SerializeField] private List<Material> NewMaterials = new List<Material>();
    private int oldcount;
    public static SpellMixManager instance;
    
    public void SpellFuse(SpellProperty SP1, SpellProperty SP2)
    {
        #region Burning/Wet
        if ((SP1.Burning || SP2.Burning) && (SP1.Wet || SP2.Wet))
        {
            if (SP1.Wet == true)
            {
                        //Vector3 temp = new Vector3();
                // add shrinking effect 
                Instantiate(Spellojects[0],new Vector3(SP1.transform.position.x, SP1.transform.position.y, SP1.transform.position.z), Quaternion.identity);
            }
            if (SP2.Wet == true)
            {
                Vector3 temp = new Vector3();
                Instantiate(Spellojects[0],new Vector3(SP2.transform.position.x, SP2.transform.position.y, SP2.transform.position.z), Quaternion.identity);
            }
            DestroyAll(SP1.GameObject(),SP2.GameObject());
        }
        #endregion
        #region Burning/Frozen
        if ((SP1.Burning || SP2.Burning) && (SP1.Frozen || SP2.Frozen))
        {
            if (SP1.Burning == true)
            {
                Instantiate(Spellojects[2],new Vector3(SP2.transform.position.x, SP2.transform.position.y, SP2.transform.position.z), Quaternion.identity);
            }
            if (SP2.Burning == true)
            {
                Instantiate(Spellojects[2],new Vector3(SP1.transform.position.x, SP1.transform.position.y, SP1.transform.position.z), Quaternion.identity);
            }
            DestroyAll(SP1.GameObject(),SP2.GameObject());
        }
        #endregion
        #region Burning/Steel
        if((SP1.Burning || SP2.Burning) && (SP1.Burning || SP2.Burning))
            if (SP1.Burning == true)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[0];
            }
        if (SP2.Burning == true)
        {
            SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[0];
        }
        

        #endregion

        #region Burning/Windy

        if((SP1.Burning || SP2.Burning) && (SP1.Windy || SP2.Windy))
            if (SP1.Burning)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
                SP2.Burning = true;
            }
            if (SP2.Burning)
            {
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
                SP1.Burning = true;
            }

        #endregion
        // Issue with interaction Below, return to solve later.   
        #region Wet/Frozen
        if((SP1.Frozen || SP2.Frozen) && (SP1.Wet || SP2.Wet))
        {
            if(SP1.Wet == true)
            {
                Debug.Log("yippie");
                SP1.Wet = false;
                SP1.Frozen = true;
            }
            if(SP2.Wet == true)
            {
                Debug.Log("yippie");
                SP2.Wet = false;
                SP2.Frozen = true;
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
    private void DestroyAll(GameObject S1, GameObject S2)
    {
        Destroy(S1);
        Destroy(S2);
    }
}