using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Action<EnemyController> EnemyDie;

    private EnemySetting _enemySetting;
    private int _currentHealth;
    private NavMeshAgent _navMeshAgent;
    private Transform _target;

    public void Init(EnemySetting enemySetting, Transform target)
    {
        _enemySetting = enemySetting;
        _target = target;
        _currentHealth = _enemySetting.MaxHealth;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _enemySetting.Speed;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        var go = other.gameObject;

        if (go.CompareTag("Player"))
        {
            go.GetComponent<TankHealth>().TakeDamage(_enemySetting.Damage);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= (damage - damage * _enemySetting.Defence / 100);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (EnemyDie != null)
        {
            EnemyDie(this);
        }

        Destroy(gameObject);
    }
}