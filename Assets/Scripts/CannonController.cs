using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _bullet;

    private int _damage;
    private float _bulletSpeed;
    private float _fireRate;

    public float FireRate
    {
        get { return _fireRate; }
    }

    public void Init(CannonSetting setting)
    {
        _damage = setting.Damage;
        _bulletSpeed = setting.BulletSpeed;
        _fireRate = setting.FireRate;
    }

    public void Fire()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            var bullet = Instantiate(_bullet, spawnPoint);
            
        }
    }
}