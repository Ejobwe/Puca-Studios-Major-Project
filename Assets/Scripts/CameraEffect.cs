using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class CameraEffect : MonoBehaviour
{
    private ObjectFader fader;
   [SerializeField] private LayerMask blocker;

    public List<GameObject> blocked = new List<GameObject>();
    public List<GameObject> noblocked = new List<GameObject>();


    GameObject player;

    // Update is called once per frame

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        

        if(player != null)
        {
            Vector3 dir = player.transform.position - transform.position;

            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, dir, Mathf.Infinity, blocker);
            
            for(int i = 0; i < hits.Length; i++)
            {
                blocked[i] = hits[i].collider.gameObject;
            }

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];

                // fader = hit.collider.gameObject.GetComponent<ObjectFader>();

                if (hit.collider.gameObject != player)
                {
                    
                    noblocked.Add(hit.collider.gameObject);
                }
                if(hit.collider.gameObject == player)
                {
                    for(int j = 0; j < hits.Length; j++)
                    {
                        if (!blocked.Contains(noblocked[j]))
                        {
                            noblocked[j].GetComponent<ObjectFader>().doFade = false;
                            noblocked.Remove(noblocked[j]);
                        }
                    }
                }
                    if (blocked.Contains(hit.collider.gameObject))
                    {
                        blocked[i].GetComponent<ObjectFader>().doFade = true;
                    
                    }
                    
                }

            }

            //Ray ray = new Ray(transform.position, dir);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.collider == null)
            //    {
            //        return;
            //    }

            //    if (hit.collider.gameObject == player)
            //    {
            //        if (fader != null)
            //        {
            //            fader.doFade = false;
            //        }
            //    }
            //    else
            //    {
            //        fader = hit.collider.gameObject.GetComponent<ObjectFader>();
            //        if (fader != null)
            //        {
            //            fader.doFade = true;
            //        }
            //    }
            //}
        }
    }

