using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<EnemySetting> _enemySettings = new List<EnemySetting>();
    private float _width;
    private float _height;
    private Transform _target;

    private void Start()
    {
        _height = Camera.main.orthographicSize / 2;
        _width = _height * Camera.main.aspect;
        _enemySettings = Resources.LoadAll("Enemies", typeof(EnemySetting)).Cast<EnemySetting>().ToList();
        _target = FindObjectOfType<TankController>().transform;

        for (int i = 0; i < 10; i++)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        var random = Random.Range(0, _enemySettings.Count);
        var settings = _enemySettings[random];
        var enemy = Instantiate(settings.EnemyPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<EnemyController>();
        enemy.Init(settings, _target);
        enemy.EnemyDie += OnEnemyDie;
    }

    private void OnEnemyDie(EnemyController diedEnemy)
    {
        diedEnemy.EnemyDie -= OnEnemyDie;
        SpawnNewEnemy();
    }

    private Vector3 GetRandomPosition()
    {
        var randomDirection = Random.Range(0, 4);

        switch (randomDirection)
        {
            case 0:
                return GetRandomTopPosition();
            case 1:
                return GetRandomBottomPosition();
            case 2:
                return GetRandomLeftPosition();
            case 3:
                return GetRandomRightPosition();
            default:
                return GetRandomTopPosition();
        }
    }

    private Vector3 GetRandomTopPosition()
    {
        return new Vector3(Random.Range(-_height, _height), 0, _width + 4);
    }

    private Vector3 GetRandomBottomPosition()
    {
        return new Vector3(Random.Range(-_height, _height), 0, -_width - 4);
    }

    private Vector3 GetRandomLeftPosition()
    {
        return new Vector3(-_width * 2 - 4, 0, Random.Range(-_height, _height));
    }

    private Vector3 GetRandomRightPosition()
    {
        return new Vector3(_width * 2 + 4, 0, Random.Range(-_height, _height));
    }
}