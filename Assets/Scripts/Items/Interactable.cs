
using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float Radius = 2f;
    [SerializeField] private Item item;
    [SerializeField] private bool grabbable;

    [SerializeField] private GameObject pickupUI;

    private void Awake()
    {
        if (pickupUI == null)
            pickupUI = GameObject.FindWithTag("pickupUI");
        else
            Debug.Log("Missing Pickup UI Game Object");
    }

    private void Start()
    {
        if (pickupUI != null)
            pickupUI.transform.GetChild(0).gameObject.SetActive(false);
    }

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
            pickupUI.transform.GetChild(0).gameObject.SetActive(true);
            grabbable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("io");
            pickupUI.transform.GetChild(0).gameObject.SetActive(false);
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
            pickupUI.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this.gameObject);
            Debug.Log("Collecting this" + item.name);
            item.CanCast = true;
        }
    }
}
