﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private TankSettings _tankSettings;

    private CannonHolder _cannonHolder;
    private Rigidbody _rigidbody;
    private bool _readyToShoot = true;
    private float _currentCooldown;
    private TankHealth _tankHealth;

    private void Start()
    {
        _cannonHolder = GetComponent<CannonHolder>();
        _rigidbody = GetComponent<Rigidbody>();
        _tankHealth = GetComponent<TankHealth>();

        _tankHealth.Init(_tankSettings.MaxHealth, _tankSettings.Defence);
    }

    private void FixedUpdate()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        _rigidbody.position += _rigidbody.transform.forward * verticalInput * _tankSettings.Speed * Time.deltaTime;

        _rigidbody.transform.Rotate(0, horizontalInput * _tankSettings.RotationSpeed, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (_readyToShoot)
        {
            _cannonHolder.ActiveCannon.Shoot();
            _currentCooldown = _cannonHolder.ActiveCannon.Cooldown;
            StartCoroutine(ResetCoolDown());
        }
    }

    private IEnumerator ResetCoolDown()
    {
        _readyToShoot = false;
        yield return new WaitForSeconds(_currentCooldown);
        _readyToShoot = true;
    }
}