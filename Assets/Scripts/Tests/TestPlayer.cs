﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public TestHealthBar healthBar;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
