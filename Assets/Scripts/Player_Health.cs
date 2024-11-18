using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class Player_Health : MonoBehaviour
    {
        // Start is called before the first frame update

        public int maxHealth;
        [SerializeField] private int currentHealth;

        [SerializeField] private Image[] hearts;

        public Sprite full;
        public Sprite empty;

    void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = full;
            }
            else
            {
                hearts[i].sprite = empty;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

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
    }

