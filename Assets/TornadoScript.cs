using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoScript : MonoBehaviour
{
    [SerializeField] private float rotation;
    public List<GameObject> Debris = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0,rotation,0) *Time.deltaTime);
        for(int i = 0; i < Debris.Count; i++)
        {
            if (Debris[i] != null)
            {
                Debris[i].transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
