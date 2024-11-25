using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;
    
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    [SerializeField] private int space = 4;

    void Awake()
    {
        instance = this;
    }

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough Space");
            return false;
        }
        items.Add(item);
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
