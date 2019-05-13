using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthUI : MonoBehaviour
{
    private const string TANK_CURRENT_HEALTH_TEXT = "Current health: ";

    [SerializeField] private Text _healthText;

    private TankHealth _tankHealth;

    private void Awake()
    {
        _tankHealth = FindObjectOfType<TankHealth>();
    }

    private void OnEnable()
    {
        _tankHealth.HealthChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _tankHealth.HealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(int newValue)
    {
        _healthText.text = TANK_CURRENT_HEALTH_TEXT + newValue;
    }
}