using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps {get; private set;}

    [field: Header("Enemy SFX")]
    [field: SerializeField] public EventReference enemyFootsteps {get; private set;}

    [field: Header("UI SFX")]
    [field: SerializeField] public EventReference buttonHover {get; private set;}
    [field: SerializeField] public EventReference buttonUnHover { get; private set; }
    [field: SerializeField] public EventReference buttonClick { get; private set; }

    public static FMODEvents instance {get; private set;}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Destroying duplicate FMODEvents");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
