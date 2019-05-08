using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage;
    private float _speed;
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    
    public void Init(int damage, float speed, Vector3 direction)
    {
        _damage = damage;
        _speed = speed;
        _direction = direction;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(_direction * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //other.TakeDamage(_damage);
        }
    }
}