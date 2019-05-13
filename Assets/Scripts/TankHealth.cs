using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public Action TankDied;
    public Action<int> HealthChanged;

    private int _currentHealth;
    private int _maxHealth;
    private int _defence;

    public void Init(int maxHealth, int defence)
    {
        _maxHealth = maxHealth;
        _defence = defence;
        _currentHealth = maxHealth;

        if (HealthChanged != null)
        {
            HealthChanged(_currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= (damage - damage * _defence / 100);

        if (_currentHealth <= 0)
        {
            TankDied();
        }

        if (HealthChanged != null)
        {
            HealthChanged(_currentHealth);
        }
    }

    private void TankDie()
    {
        if (TankDied != null)
        {
            TankDied();
        }
    }
}