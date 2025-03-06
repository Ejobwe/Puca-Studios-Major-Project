using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps {get; private set;}

    [field: Header("EnemySFX")]
    [field: SerializeField] public EventReference enemyFootsteps {get; private set;}


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
