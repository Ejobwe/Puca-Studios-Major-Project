
using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float Radius = 2f;
    [SerializeField] private Item item;
    [SerializeField] private bool grabbable;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Radius);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("oi");
            grabbable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("io");
            grabbable = false;
        }
    }

   void Update()
    {
        if (grabbable && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
    private void PickUp()
    {
        bool PickedUp = Inventory.instance.Add(item);
        if (PickedUp)
        {
            Destroy(this.gameObject);
            Debug.Log("Collecting this" + item.name);
        }
    }
}
