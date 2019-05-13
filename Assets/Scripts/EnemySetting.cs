using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/Enemy", order = 1)]
public class EnemySetting : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int MaxHealth;
    public float Speed;
    public int Damage;
    public int Defence;
}