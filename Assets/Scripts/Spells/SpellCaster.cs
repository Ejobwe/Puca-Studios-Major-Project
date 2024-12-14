using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BarthaSzabolcs.IsometricAiming;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    // Welcome! this is the important script for the spellcasting.
    // This script os where every spell is kept and chosen for casting.
    // Important variables for adding new spells will be explained on their line.
    [SerializeField]private GameObject Player;
    [SerializeField]private GameObject Manager;
    [SerializeField] private List<GameObject> Spells = new List<GameObject>(); // the gameobjects produced by a spell are all kept in one list in the place of their index order
    private Inventory inventory;
    public int order;
    private Item CurrentSpell; // The scriptable object in the inventory thats being used to cast the spell.            To create a new spell, simply right click in the project window > create > inventory > equipment. From there you can give it a name, icon and index number.
    [SerializeField] private GameObject SPObj;                                                                        //Please keep all equipment scriptable objects in the Inventory Spells folder.
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
        
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.items.Count == 0)
            {
                Debug.Log("Spells empty");
            }
            else
            {
                CurrentSpell = inventory.items[order];


                switch (CurrentSpell.Index)             // this switch statement finds the index number of the currently equipped spell in the inventory and calls the function of the associated spell.

                {
                    case 0:
                        Fireball();
                        break;
                    case 1:
                        SummonPuddle();
                        break;
                    case 2:
                        SummonIceWall();
                        break;
                    // new spells are added to the end of the list in order of their index number.
                }
            }
            order++;
        }
        //This continuous if/else statement is to ensure we don't get errors when adding or removing spells from the list
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
    
// The following functions each call the spell they're named after.
    #region Fireball
    private void Fireball()
    {
        SpawnPoint = SPObj.transform.position;
        GameObject clone = Instantiate(Spells[CurrentSpell.Index], SpawnPoint, Quaternion.Euler(Mpos));
        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
    }
    #endregion
    #region SummonPuddle

    private void SummonPuddle()
    {
        Instantiate(Spells[CurrentSpell.Index], isometricAiming.Pos, Quaternion.identity);
    }
    #endregion
    #region SummonIceWall
    private void SummonIceWall()
    {
        Instantiate(Spells[CurrentSpell.Index], isometricAiming.Pos, Quaternion.Euler(Player.transform.localRotation.eulerAngles));
    }
    #endregion
    
}
