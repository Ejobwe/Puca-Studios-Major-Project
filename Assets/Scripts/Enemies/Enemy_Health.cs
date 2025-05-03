using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Health : MonoBehaviour
{
    private enum EnemyType
    {
        RANGED,
        MELEE,
        BOSS
    }

    public int maxHealth;
    [SerializeField] private bool boss;
    [SerializeField] private int currentHealth;

    [SerializeField] private EnemyType enemyType;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !boss)
        {
            Destroy(gameObject);
        }
        if (currentHealth <= 0 && boss)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public void takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            switch (enemyType)
            {
                case EnemyType.RANGED:
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.rangedEnemyHit, transform.position);
                    break;
                case EnemyType.MELEE:
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.meleeEnemyHit, transform.position);
                    break;
                case EnemyType.BOSS:
                    AudioManager.instance.PlayOneShot(FMODEvents.instance.bossEnemyHit, transform.position);
                    break;
                default:
                    Debug.LogWarning("Enemy type not supported: " + enemyType);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "IceSpell")
        {
            takeDamage(other.GetComponent<IceSpell>().damage);
        }
    }
}
