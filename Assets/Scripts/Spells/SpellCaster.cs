using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BarthaSzabolcs.IsometricAiming;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private GameObject Manager;
    [SerializeField] private List<GameObject> Spells = new List<GameObject>();
    private Inventory inventory;
    private int order;
    private Item CurrentSpell;
    [SerializeField] private GameObject SPObj;
    private Vector3 SpawnPoint;
    private IsometricAiming isometricAiming;
    private Vector3 Mpos;
    private float Speed = 5f;
    
    
    

    void Start()
    {
        isometricAiming = Player.GetComponent<IsometricAiming>();
        inventory = Manager.GetComponent<Inventory>();
        order = 0;
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && order <= inventory.items.Count)
        {
            if (inventory.items != null)
            {
                CurrentSpell = inventory.items[order];
            }
            else if(inventory.items == null)
            {
             Debug.Log("nothing to cast");   
            }
            
            switch (CurrentSpell.Index)
            
            {
                case 0:
                    Debug.Log(" firing a" + CurrentSpell.name);
                    Fireball();
                    break;
                case 1:
                    Debug.Log(" firing a" + CurrentSpell.name);
                    SummonPuddle();
                    break;
                case 2:
                    SummonIceWall();
                    break;
            }

            order++;
            if (order >= inventory.items.Count)
            {
                order = 0;
            }
            else if (order > inventory.items.Count())
            {
                Debug.Log("Resetting spells");
                order = 0;
            }
            else if (inventory.items == null)
            {
                Debug.Log("Spells empty");
            }
        }

    }

    private void Fireball()
    {
        SpawnPoint = SPObj.transform.position;
        GameObject clone = Instantiate(Spells[CurrentSpell.Index], SpawnPoint, Quaternion.Euler(Mpos));
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
    }

    private void SummonPuddle()
    {
        Instantiate(Spells[CurrentSpell.Index], isometricAiming.Pos, Quaternion.identity);
    }
    
    private void SummonIceWall()
    {
        Instantiate(Spells[CurrentSpell.Index], isometricAiming.Pos, Quaternion.Euler(Player.transform.localRotation.eulerAngles));
    }
    
    
}
