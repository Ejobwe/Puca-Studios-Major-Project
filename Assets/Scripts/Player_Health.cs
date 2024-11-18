using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth;
    [SerializeField] private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void takeDamage(int damage)
    {
        if(currentHealth > 0) { 
            currentHealth -= damage;
        }
    }
}
