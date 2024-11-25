using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    private Equipment[] currentEquipment;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        int numSlots = 4;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        
    }
}
