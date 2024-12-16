using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    public void takeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
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
