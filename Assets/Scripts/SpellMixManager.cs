//using System;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpellMixManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> Spellojects = new List<GameObject>();
    [SerializeField] private List<Material> NewMaterials = new List<Material>();
    private int oldcount;
    public static SpellMixManager instance;
    
    
    public void SpellFuse(SpellProperty SP1, SpellProperty SP2)
    {
        #region Burning/Burning

        if (SP1.Burning && SP1.Wet == false && SP1.Frozen == false && SP1.Metal == false && SP1.Windy == false &&
            SP1.Electric == false && SP1.Planty == false && SP2.Burning && SP2.Wet == false && SP2.Frozen == false &&
            SP2.Metal == false && SP2.Windy == false && SP2.Electric == false && SP2.Planty == false)
        {
            return;
        }
        #endregion
        
        #region Burning/Wet
        if ((SP1.Burning || SP2.Burning) && (SP1.Wet || SP2.Wet))
        {
            if (SP1.Burning == true)
            {
                        //Vector3 temp = new Vector3();
                // add shrinking effect 
                Instantiate(Spellojects[0],new Vector3(SP2.transform.position.x, SP2.transform.position.y, SP2.transform.position.z), Quaternion.identity);
            }
            if (SP2.Burning == true)
            {
                Instantiate(Spellojects[0],new Vector3(SP1.transform.position.x, SP1.transform.position.y, SP1.transform.position.z), Quaternion.identity);
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
        #region Burning/Metal
        if((SP1.Burning || SP2.Burning) && (SP1.Metal || SP2.Metal))
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
            if (SP1.Burning && SP1.Windy == false)
            {
                Destroy(SP1.GameObject());
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
            }
            if (SP2.Burning && SP2.Windy == false)
            {
                Destroy(SP2.GameObject());
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
            }
            if (SP1.Burning == true )
            {
                SP2.Burning = true;
                SP2.Extension = 5;
                SP2.Extended = true;
                return;
            }
            if (SP2.Burning == true)
            {
                SP1.Burning = true;
                SP1.Extension = 5;
                SP1.Extended = true;
                return;
            }
        #endregion
        #region Burning/Electric

        if ((SP1.Burning || SP2.Burning) && (SP1.Electric || SP2.Electric))
        {
            if (SP1.Burning == true)
            {
                SP2.Burning = true;
            }
            if (SP2.Burning == true)
            {
                SP1.Burning = true;
            }
        }

        #endregion
        #region Burning/Planty
        if ((SP1.Burning || SP2.Burning) && (SP1.Planty || SP2.Planty))
        {
            if (SP1.Burning == true && SP1.Planty == false)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
            }
            if (SP2.Burning == true && SP2.Planty == false)
            {
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[1];
            }
            if (SP1.Burning == true && SP1.Planty == false)
            {
                SP2.Extension = 5;
                SP2.Extended = true;
                SP2.Planty = false;
                SP2.Burning = true;
                return;
            }
            if (SP2.Burning == true && SP2.Planty == false)
            {
                SP1.Extension = 5;
                SP1.Extended = true;
                SP1.Planty = false;
                SP1.Burning = true;
                return;
            }
        }
        #endregion
        #region Burning/Earthy
        if ((SP1.Burning || SP2.Burning) && (SP1.Earthy || SP2.Earthy))
            if (SP1.Burning == true)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[3];
            }
            if (SP2.Burning == true && SP2.Earthy == false)
            {   
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[3];
            }
            if (SP1.Burning == true && SP1.Earthy == false)
            {
                SP2.Burning = true;
                SP2.Extension = 5;
                SP2.Extended = true;
                return;
            }
            if (SP2.Burning == true && SP2.Earthy == false)
            {
                SP1.Burning = true;
                SP1.Extension = 5;
                SP1.Extended = true;
                return;
            }
        #endregion
        
        #region Wet/Frozen
        if((SP1.Frozen || SP2.Frozen) && (SP1.Wet || SP2.Wet))
        {
            if(SP1.Wet == true)
            {
                
                Debug.Log("yippie");
                SP1.Wet = false;
                SP1.Frozen = true;
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
            }
            if(SP2.Wet == true)
            {
                Debug.Log("yippie");
                SP2.Wet = false;
                SP2.Frozen = true;
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
            }
        }
        #endregion
        #region Wet/Metal

        if ((SP1.Wet || SP2.Wet) && (SP1.Metal || SP2.Metal))
        {
            if (SP1.Wet && SP1.Metal == false)
            {
                
            }
            if (SP1.Wet && SP1.Metal == false)
            {
                
            }
        }

        #endregion
        #region Wet/Windy

        if ((SP1.Wet || SP2.Wet) && (SP1.Windy || SP2.Windy))
            if (SP1.Wet && SP1.Windy == false)
            {
                
            }
            if (SP1.Wet && SP1.Windy == false)
            {
                
            }

        #endregion
        #region Wet/Electric

        if ((SP1.Wet || SP2.Wet) && (SP1.Electric || SP2.Electric))
        {
            if (SP1.Wet)
            {
                SP1.Electric = true;
            }

            if (SP1.Wet)
            {
                SP2.Electric = true;
            }
        }

        #endregion
        #region Wet/Planty

        if ((SP1.Wet || SP2.Wet) && (SP2.Planty || SP2.Planty))
        {
            if(SP1.Wet)
            {
                Destroy(SP1.GameObject());
                var temp = new Vector3();
                temp = SP2.gameObject.transform.localScale;
                temp.x += 3;
                temp.y += 0.3f;
                temp.z += 3;
                SP2.gameObject.transform.localScale = temp;
                return;
            }
            if(SP2.Wet)
            {
                Destroy(SP2.GameObject());
                var temp = new Vector3();
                temp = SP1.gameObject.transform.localScale;
                temp.x += 3;
                temp.y += 0.3f;
                temp.z += 3;
                SP1.gameObject.transform.localScale = temp;
                return;
            }

        }



        #endregion
        #region Wet/Earthy

        if ((SP1.Wet || SP2.Wet) && (SP1.Earthy || SP2.Earthy))
        {
            if (SP1.Wet && SP1.Earthy == false)
            {
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[4];
            }

            if (SP2.Wet && SP2.Earthy == false)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[4];
            }
            if (SP1.Wet && SP1.Earthy == false)
            {
                SP1.Earthy = true;
                return;
            }
            if (SP2.Wet && SP2.Earthy == false)
            {
                SP2.Earthy = true;
                return;
            }
            
        }

        #endregion
        
        #region Frozen/Metal
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
        #region Frozen/Windy

        if ((SP1.Frozen || SP2.Frozen) && (SP1.Windy || SP2.Windy))
        {
            if (SP1.Frozen & SP1.Windy == false)
            {
                
            }

            if (SP2.Frozen && SP2.Windy == false)
            {
                
            }
        }
        #endregion
        #region Frozen/Electric
        if ((SP1.Frozen || SP2.Frozen) && (SP1.Electric || SP2.Electric))
        {
            if (SP1.Frozen & SP1.Electric == false)
            {
                
            }

            if (SP2.Frozen && SP2.Electric == false)
            {
                
            }
        }
        

        #endregion
        #region Frozen/Planty
        if ((SP1.Frozen || SP2.Frozen) && (SP1.Planty || SP2.Planty))
        {
            if (SP1.Frozen & SP1.Planty == false)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
                SP2.Planty = false;
                SP2.Frozen = true;
            }

            if (SP2.Frozen && SP2.Planty == false)
            {
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
                SP1.Planty = false;
                SP1.Frozen = true;
            }
        }

        #endregion
        #region Frozen/Earthy
        if ((SP1.Frozen || SP2.Frozen) && (SP1.Earthy || SP2.Earthy))
        {
            if (SP1.Frozen & SP1.Earthy == false)
            {
                SP2.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
                SP2.Earthy = false;
                SP2.Frozen = true;
            }

            if (SP2.Frozen && SP2.Earthy == false)
            {
                SP1.GameObject().GetComponent<Renderer>().material = NewMaterials[2];
                SP1.Planty = false;
                SP1.Frozen = true;
            }
        }
        

        #endregion

        #region Metal/Windy

        if ((SP1.Metal || SP2.Metal) && (SP1.Windy || SP2.Windy))
        {
         TornadoScript tornadoScript;
            if (SP1.Metal && SP1.Windy == false)
            {
                tornadoScript = SP2.gameObject.GetComponent<TornadoScript>();
                tornadoScript.Debris.Add(SP1.GameObject());
            }
            if (SP2.Metal && SP2.Windy == false)
            {
                tornadoScript = SP1.gameObject.GetComponent<TornadoScript>();
                tornadoScript.Debris.Add(SP2.GameObject());
            }
        }

        #endregion
        #region Metal/Electric

        

        #endregion
        #region Metal/Planty

        

        #endregion
        #region Metal/Earthy

        

        #endregion

        #region Windy/Electric

        if ((SP1.Windy || SP2.Windy) && (SP1.Electric || SP2.Electric))
        {
            if (SP1.Windy && SP1.Electric == false)
            {
                SP1.Electric = true;
                return;
            }
            if (SP2.Windy && SP2.Electric == false)
            {
                SP2.Electric = true;
                return;
            }
                
        }

        #endregion
        #region Windy/Planty

        

        #endregion

        #region Windy/Earthy
        if ((SP1.Earthy || SP2.Earthy) && (SP1.Windy || SP2.Windy))
        {
            TornadoScript tornadoScript;
            if (SP1.Earthy && SP1.Windy == false)
            {
                tornadoScript = SP2.gameObject.GetComponent<TornadoScript>();
                tornadoScript.Debris.Add(SP1.GameObject());
                SP1.Extension = 5;
                SP1.Extended = true;
                return;
            }
            if (SP2.Earthy && SP2.Windy == false)
            {
                tornadoScript = SP1.gameObject.GetComponent<TornadoScript>();
                tornadoScript.Debris.Add(SP2.GameObject());
                SP2.Extension = 5;
                SP2.Extended = true;
                return;
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