using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CannonsSettings", menuName = "Cannons/Cannon", order = 1)]
public class CannonSetting : ScriptableObject
{
    public GameObject CannonPrefab;
    public int Damage;
    public float Cooldown;
    public float BulletSpeed;
}
