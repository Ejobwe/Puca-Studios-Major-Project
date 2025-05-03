using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambiencePlaceHolder { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }
    [field: SerializeField] public EventReference playerHit { get; private set; }
    [field: SerializeField] public EventReference playerDeath { get; private set; }

    [field: Header("Enemy SFX")]
    [field: SerializeField] public EventReference eightLeggedEnemyFootsteps { get; private set; }
    [field: SerializeField] public EventReference sixLeggedEnemyFootsteps { get; private set; }
    [field: SerializeField] public EventReference rangedEnemyAttack { get; private set; }
    [field: SerializeField] public EventReference meleeEnemyAttack { get; private set; }
    [field: SerializeField] public EventReference bossEnemyAttack { get; private set; }
    [field: SerializeField] public EventReference rangedEnemyHit { get; private set; }
    [field: SerializeField] public EventReference meleeEnemyHit { get; private set; }
    [field: SerializeField] public EventReference bossEnemyHit { get; private set; }

    [field: Header("UI SFX")]
    [field: SerializeField] public EventReference buttonHover { get; private set; }
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
