using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _bullet;

    private int _damage;
    private float _bulletSpeed;
    private float _cooldown;

    public float Cooldown => _cooldown;

    public void Init(CannonSetting setting)
    {
        _damage = setting.Damage;
        _bulletSpeed = setting.BulletSpeed;
        _cooldown = setting.Cooldown;
    }

    public void Shoot()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            var bullet = Instantiate(_bullet, spawnPoint.position, Quaternion.identity).GetComponent<Bullet>();

            bullet.Init(_damage, _bulletSpeed, -spawnPoint.right);
        }
    }
}