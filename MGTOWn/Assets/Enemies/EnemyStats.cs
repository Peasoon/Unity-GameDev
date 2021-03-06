﻿using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public GameObject healthbar;
    public int maxHealth;
    public int damage;

    public GameObject drop;

    int currentHealth;

    Slider healthbarSlider;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        healthbarSlider = healthbar.GetComponent<Slider>();

        currentHealth = maxHealth;
        healthbarSlider.maxValue = maxHealth;
    }

    public void CurrentHealthDisplay()
    {
        healthbar.SetActive(true);
        healthbarSlider.value = currentHealth;
    }

    public void TakingDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            animator.SetBool("isDead", true);
        }
    }

    void Die()
    {
        GameObject tempDrop = Instantiate(drop as GameObject);

        tempDrop.SetActive(false);
        tempDrop.transform.position = gameObject.transform.position;

        Destroy(gameObject);

        tempDrop.SetActive(true);
    }
}
